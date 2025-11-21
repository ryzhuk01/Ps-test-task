using FluentValidation;
using System.Text.Json;

namespace Ps.Application.Submissions.Commands.CreateSubmission;

public class CreateSubmissionCommandValidator : AbstractValidator<CreateSubmissionCommand>
{
    public CreateSubmissionCommandValidator()
    {
        RuleFor(x => x.FormName)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.FormData)
            .Must(d => d.ValueKind == JsonValueKind.Object && d.EnumerateObject().Any())
            .WithMessage("FormData cannot be empty.");
    }
}