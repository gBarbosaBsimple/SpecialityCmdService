using Domain.Models;

namespace Domain.Visitors
{
    public interface ISpecialityVisitor
    {
        public Guid Id { get; }
        public string Description { get; }
        public Guid TechnologyId { get; }
        public Guid CollaboratorId { get; }
        public PeriodDate PeriodDate { get; }
    }
}