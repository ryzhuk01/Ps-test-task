using BuildingBlocks.Persistence.Abstractions;
using Ps.Core.Entities;
namespace Ps.Core.Common.Interfaces;

public interface IFormSubmissionRepository: IRepositoryBase<FormSubmission>
{
    ValueTask<FormSubmission?> GetFormSubmissionAsync(Guid id, CancellationToken cancellationToken);
    Task<List<FormSubmission>> GetFormSubmissionsAsync(string? searchTerm, CancellationToken cancellationToken);
}