using System.Text.Json;

namespace Ps.Application.Submissions.Queries;

public record SubmissionResult
{
    public Guid Id { get; init; }
    public required string FormName { get; init; }
    public required JsonElement FormData { get; init; }
    public DateTime SubmittedAt { get; init; }
}
