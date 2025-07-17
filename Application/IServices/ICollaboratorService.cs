using Domain.Interfaces;
using Domain.Models;

namespace Application.Interfaces
{
    public interface ICollaboratorService
    {
        Task<ICollaborator> SubmitCollaboratorAsync(Guid collaboratorId);
    }
}