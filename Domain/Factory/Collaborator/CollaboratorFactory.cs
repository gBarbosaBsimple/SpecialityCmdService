using Domain.Models;
using Domain.Visitors;

namespace Domain.Factory.CollaboratorFactory
{
    public class CollaboratorFactory : ICollaboratorFactory
    {
        public CollaboratorFactory() { }

        public Collaborator Create(Guid id)
        {
            return new Collaborator(id);
        }

        public Collaborator Create(ICollaboratorVisitor visitor)
        {
            return new Collaborator(visitor.Id);
        }
    }
}