using Domain.Models;

namespace Domain.Messages
{
    public record SpecialityCreatedMessage(Guid SpecialityId, string Description, Guid TechnologyId, Guid CollaboratorId, PeriodDate PeriodDate);
}