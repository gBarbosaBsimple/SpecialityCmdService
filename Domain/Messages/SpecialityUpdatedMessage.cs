using Domain.Models;

namespace Domain.Messages
{
    public record SpecialityUpdatedMessage(Guid SpecialityId, string Description, Guid TechnologyId, Guid CollaboratorId, PeriodDate PeriodDate);
}