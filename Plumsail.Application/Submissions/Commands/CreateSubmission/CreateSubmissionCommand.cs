using BuildingBlocks.Cqrs.Abstractions;
using System.Text.Json;

namespace Plumsail.Application.Submissions.Commands.CreateSubmission;

public record CreateSubmissionCommand(string FormName, JsonElement FormData) : ICommand<Guid>;