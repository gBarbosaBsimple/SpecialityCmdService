using AutoMapper;
using Domain.Interfaces;
using Domain.IRepository;
using Domain.Models;
using Infrastructure.DataModel;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{

    public class CollaboratorRepositoryEF : ICollaboratorRepositoryEF
    {
        private readonly IMapper _mapper;
        private readonly AbsanteeContext _context;

        public CollaboratorRepositoryEF(IMapper mapper, AbsanteeContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Collaborator?> GetByIdAsync(Guid id)
        {
            var collaboratorDM = await _context.Collaborators
    .Where(c => c.Id == id)
    .FirstOrDefaultAsync();
            var collaborator = _mapper.Map<Collaborator>(collaboratorDM);
            return collaborator;
        }

        public async Task<ICollaborator> AddCollaboratorAsync(ICollaborator collaborator)
        {
            var collaboratorDM = _mapper.Map<CollaboratorDataModel>(collaborator);

            await _context.Collaborators.AddAsync(collaboratorDM);
            await _context.SaveChangesAsync();

            var collaboratorAdded = _mapper.Map<ICollaborator>(collaboratorDM);
            return collaboratorAdded;
        }
    }
}