using Domain.Interfaces;
using Domain.Models;
using Domain.Visitors;

namespace Infrastructure.DataModel
{

    public class SpecialityDataModel : ISpecialityVisitor
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid TechnologyId { get; set; }

        public Guid CollaboratorId { get; set; }

        public PeriodDate PeriodDate { get; set; }

        public SpecialityDataModel() { }

        public SpecialityDataModel(ISpeciality speciality)
        {
            Id = speciality.Id;
            Description = speciality.Description;
            TechnologyId = speciality.TechnologyId;
            CollaboratorId = speciality.CollaboratorId;
            PeriodDate = speciality.PeriodDate;
        }
    }
}