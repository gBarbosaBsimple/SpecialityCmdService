using Domain.Models;
using Domain.Visitors;

namespace Domain.Factory.CollaboratorFactory
{
    public interface ICollaboratorFactory
    {
        Collaborator Create(Guid id);
        Collaborator Create(ICollaboratorVisitor visitor);
    }
}