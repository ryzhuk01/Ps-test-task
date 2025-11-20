using BuildingBlocks.Cqrs.Abstractions;

namespace Plumsail.Application.Submissions.Queries;

public record GetSubmissionsQuery(string? SearchTerm) : IQuery<List<SubmissionResult>>;