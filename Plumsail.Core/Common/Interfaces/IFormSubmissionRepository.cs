using BuildingBlocks.Persistence.Abstractions;
using Plumsail.Core.Entities;
namespace Plumsail.Core.Common.Interfaces;

public interface IFormSubmissionRepository: IRepositoryBase<FormSubmission>
{
    ValueTask<FormSubmission?> GetFormSubmissionAsync(Guid id, CancellationToken cancellationToken);
    Task<List<FormSubmission>> GetFormSubmissionsAsync(string? searchTerm, CancellationToken cancellationToken);
}