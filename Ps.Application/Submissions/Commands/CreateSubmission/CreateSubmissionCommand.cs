using BuildingBlocks.Cqrs.Abstractions;
using System.Text.Json;

namespace Ps.Application.Submissions.Commands.CreateSubmission;

public record CreateSubmissionCommand(string FormName, JsonElement FormData) : ICommand<Guid>;