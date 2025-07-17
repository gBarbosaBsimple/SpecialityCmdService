using Domain.Interfaces;
using Domain.Models;

namespace Domain.IRepository
{
    public interface ICollaboratorRepositoryEF
    {
        Task<Collaborator?> GetByIdAsync(Guid id);
        Task<ICollaborator> AddCollaboratorAsync(ICollaborator collaborator);

    }
}