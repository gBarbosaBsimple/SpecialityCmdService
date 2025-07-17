using Domain.Models;

namespace Domain.Interfaces
{
    public interface ISpeciality
    {
        Guid Id { get; }
        string Description { get; }
        Guid TechnologyId { get; }
        Guid CollaboratorId { get; }
        PeriodDate PeriodDate { get; }

        void TechnologyUpdate(Guid technologyId);
        void CollaboratorUpdate(Guid collaboratorId);
        void PeriodDateUpdate(PeriodDate periodDate);
    }
}
