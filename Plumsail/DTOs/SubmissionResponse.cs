using System.Text.Json;

namespace Plumsail.Api.DTOs;

public record SubmissionResponse(
    Guid Id,
    string FormName,
    JsonElement FormData,
    DateTime SubmittedAt
);
