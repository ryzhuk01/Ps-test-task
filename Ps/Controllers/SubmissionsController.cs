using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ps.Api.DTOs;
using Ps.Application.Submissions.Commands.CreateSubmission;
using Ps.Application.Submissions.Queries;

namespace Ps.Api.Controllers;

[ApiController]
[Route("api/submissions")]
public class SubmissionsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<SubmissionResponse>>> GetAsync(
        [FromQuery] string? search,
        CancellationToken cancellationToken)
    {
        var query = new GetSubmissionsQuery(search);
        var result = await mediator.Send(query, cancellationToken);

        var response = result.Select(x => new SubmissionResponse(
            x.Id,
            x.FormName,
            x.FormData,
            x.SubmittedAt
        ));

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromBody] CreateSubmissionRequest request,
        CancellationToken cancellationToken)
    {
        var command = new CreateSubmissionCommand(request.FormName, request.FormData);

        var id = await mediator.Send(command, cancellationToken);

        return Created(string.Empty, new { id });
    }
}
