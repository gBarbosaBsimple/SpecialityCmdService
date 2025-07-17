using Domain.Models;

namespace Domain.Visitors
{
    public interface ICollaboratorVisitor
    {
        public Guid Id { get; }
    }
}