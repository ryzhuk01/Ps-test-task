using BuildingBlocks.Persistence.Abstractions;
using Microsoft.EntityFrameworkCore;
using Plumsail.Core.Common.Interfaces;
using Plumsail.Core.Entities;
using Plumsail.Infrastructure.Persistence;
using System.Text.Json;

namespace Plumsail.Infrastructure.Repositories;

public class FormSubmissionRepository(ApplicationDbContext context) :
    RepositoryBase<FormSubmission>(context),
    IFormSubmissionRepository
{
    public ValueTask<FormSubmission?> GetFormSubmissionAsync(Guid id, CancellationToken cancellationToken) =>
        _dbSet.FindAsync([id], cancellationToken);

    public async Task<List<FormSubmission>> GetFormSubmissionsAsync(string? searchTerm, CancellationToken cancellationToken)
    {
        var query = _dbSet.AsNoTracking();

        var submissions = query
            .OrderByDescending(x => x.SubmittedAt);

        if (string.IsNullOrWhiteSpace(searchTerm))
        {
            return await submissions.ToListAsync(cancellationToken);
        }

        var lowerTerm = searchTerm.ToLower();

        return [.. submissions
            .Where(x =>
                x.FormName.Contains(lowerTerm, StringComparison.CurrentCultureIgnoreCase) ||
                ContainsValue(x.FormDataJson, lowerTerm))];
    }

    private static bool ContainsValue(string json, string searchTerm)
    {
        try
        {
            using var doc = JsonDocument.Parse(json);
            return ContainsValue(doc.RootElement, searchTerm);
        }
        catch
        {
            return false;
        }
    }

    private static bool ContainsValue(JsonElement element, string searchTerm)
    {
        switch (element.ValueKind)
        {
            case JsonValueKind.Object:
                foreach (var property in element.EnumerateObject())
                {
                    if (ContainsValue(property.Value, searchTerm))
                    {
                        return true;
                    }
                }
                return false;

            case JsonValueKind.Array:
                foreach (var item in element.EnumerateArray())
                {
                    if (ContainsValue(item, searchTerm))
                    {
                        return true;
                    }
                }
                return false;

            case JsonValueKind.String:
                var value = element.GetString();
                return value != null && value.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase);

            default:
                return false;
        }
    }
};
