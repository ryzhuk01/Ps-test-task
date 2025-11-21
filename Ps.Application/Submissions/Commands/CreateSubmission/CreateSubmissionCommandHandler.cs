using BuildingBlocks.Cqrs.Abstractions;
using Ps.Core.Common.Interfaces;
using Ps.Core.Entities;

namespace Ps.Application.Submissions.Commands.CreateSubmission;

public class CreateSubmissionCommandHandler(IFormSubmissionRepository formSubmissionRepository) : ICommandHandler<CreateSubmissionCommand, Guid>
{
    public async Task<Guid> Handle(CreateSubmissionCommand request, CancellationToken cancellationToken)
    {
        var submission = new FormSubmission
        {
            Id = Guid.NewGuid(),
            FormName = request.FormName,
            FormDataJson = request.FormData.GetRawText(),
            SubmittedAt = DateTime.UtcNow
        };

        await formSubmissionRepository.AddAsync(submission, cancellationToken);
        await formSubmissionRepository.SaveChangesAsync(cancellationToken);

        return submission.Id;
    }
}
