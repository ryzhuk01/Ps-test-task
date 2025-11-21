using System.Text.Json;

namespace Ps.Api.DTOs;

public record SubmissionResponse(
    Guid Id,
    string FormName,
    JsonElement FormData,
    DateTime SubmittedAt
);
