using Domain.Models;
using Domain.Visitors;

namespace Domain.Factory.TechnologyFactory
{

    public interface ITechnologyFactory
    {
        Technology Create(Guid id, string description);
        Technology Create(ITechnologyVisitor visitor);
    }
}