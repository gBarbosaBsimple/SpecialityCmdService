using Domain.Interfaces;
using Domain.Visitors;

namespace Infrastructure.DataModel
{

    public class TechnologyDataModel : ITechnologyVisitor
    {
        public Guid Id { get; set; }
        public string Description { get; set; }

        public TechnologyDataModel(ITechnology technology)
        {
            Id = technology.Id;
            Description = technology.Description;
        }
        public TechnologyDataModel() { }
    }
}