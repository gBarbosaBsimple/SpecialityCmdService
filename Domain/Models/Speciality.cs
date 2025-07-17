using Domain.Interfaces;

namespace Domain.Models
{
    public class Speciality : ISpeciality
    {
        public Guid Id { get; private set; }
        public string Description { get; private set; }
        public Guid TechnologyId { get; private set; }
        public Guid CollaboratorId { get; private set; }
        public PeriodDate PeriodDate { get; private set; }

        public Speciality(Guid id, string description, Guid technologyId, Guid collaboratorId, PeriodDate periodDate)
        {
            Id = id;
            Description = description;
            TechnologyId = technologyId;
            CollaboratorId = collaboratorId;
            PeriodDate = periodDate;
        }

        public Speciality(string description, Guid technologyId, Guid collaboratorId, PeriodDate periodDate)
        {
            Id = Guid.NewGuid();
            TechnologyId = technologyId;
            Description = description;
            CollaboratorId = collaboratorId;
            PeriodDate = periodDate;
        }

        public Speciality() { }

        public void TechnologyUpdate(Guid technologyId)
        {
            if (technologyId == Guid.Empty)
                throw new ArgumentException("technologyiD can t be empty");

            TechnologyId = technologyId;
        }

        public void CollaboratorUpdate(Guid collaboratorId)
        {
            if (collaboratorId == Guid.Empty)
                throw new ArgumentException("collabiD can t be empty");

            CollaboratorId = collaboratorId;
        }

        public void PeriodDateUpdate(PeriodDate periodDate)
        {
            if (periodDate is null)
                throw new ArgumentNullException(nameof(periodDate));

            PeriodDate = periodDate;
        }
    }
}