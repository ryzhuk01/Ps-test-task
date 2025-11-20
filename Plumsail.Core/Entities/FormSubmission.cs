using BuildingBlocks.Persistence.Abstractions;

namespace Plumsail.Core.Entities;

public class FormSubmission: Entity
{
    public required string FormName { get; set; }
    public required string FormDataJson { get; set; }
    public DateTime SubmittedAt { get; set; }
}
