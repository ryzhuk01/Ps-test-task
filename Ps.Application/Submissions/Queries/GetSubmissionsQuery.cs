using BuildingBlocks.Cqrs.Abstractions;

namespace Ps.Application.Submissions.Queries;

public record GetSubmissionsQuery(string? SearchTerm) : IQuery<List<SubmissionResult>>;