using Domain.Interfaces;
using Domain.Models;
using Domain.Visitors;

namespace Domain.Factory.TechnologyFactory
{
    public class TechnologyFactory : ITechnologyFactory
    {
        public Technology Create(Guid id, string description)
        {
            return new Technology(id, description);
        }

        public Technology Create(ITechnologyVisitor technologyVisitor)
        {
            return new Technology(technologyVisitor.Id, technologyVisitor.Description);
        }
    }
}