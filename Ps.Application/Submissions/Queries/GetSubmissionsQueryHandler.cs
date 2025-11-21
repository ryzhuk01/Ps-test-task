using BuildingBlocks.Cqrs.Abstractions;
using Ps.Core.Common.Interfaces;
using System.Text.Json;

namespace Ps.Application.Submissions.Queries;

public class GetSubmissionsQueryHandler(IFormSubmissionRepository formSubmissionRepository)
    : IQueryHandler<GetSubmissionsQuery, List<SubmissionResult>>
{
    public async Task<List<SubmissionResult>> Handle(GetSubmissionsQuery request, CancellationToken cancellationToken)
    {
        var entities = await formSubmissionRepository.GetFormSubmissionsAsync(request.SearchTerm, cancellationToken);

        return [.. entities.Select(x => new SubmissionResult
        {
            Id = x.Id,
            FormName = x.FormName,
            FormData = JsonSerializer.Deserialize<JsonElement>(x.FormDataJson),
            SubmittedAt = x.SubmittedAt
        })];
    }
}