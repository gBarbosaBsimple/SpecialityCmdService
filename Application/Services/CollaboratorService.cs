using Application.Interfaces;
using Domain.Factory.CollaboratorFactory;
using Domain.Interfaces;
using Domain.IRepository;
using Domain.Models;

namespace Application.Services
{
    public class CollaboratorService : ICollaboratorService
    {
        private readonly ICollaboratorRepositoryEF _collaboratorRepository;
        private readonly ICollaboratorFactory _collaboratorFactory;

        public CollaboratorService(ICollaboratorRepositoryEF CollaboratorRepository, ICollaboratorFactory CollaboratorFactory)
        {
            _collaboratorRepository = CollaboratorRepository;
            _collaboratorFactory = CollaboratorFactory;
        }

        public async Task<ICollaborator> SubmitCollaboratorAsync(Guid collaboratorId)
        {
            var collaborator = _collaboratorFactory.Create(collaboratorId);

            return await _collaboratorRepository.AddCollaboratorAsync(collaborator);
        }
    }
}