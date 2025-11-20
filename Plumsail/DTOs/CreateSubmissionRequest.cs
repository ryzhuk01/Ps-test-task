using System.Text.Json;

namespace Plumsail.Api.DTOs;

public class CreateSubmissionRequest
{
    public required string FormName { get; set; }
    public required JsonElement FormData { get; set; }
}