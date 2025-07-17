using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.IRepository;
using Domain.Models;
using Domain.Visitors;

namespace Domain.Factory.SpecialityFactory
{

    public class SpecialityFactory : ISpecialityFactory
    {
        private readonly ISpecialityRepositoryEF _specialityRepository;
        private readonly ICollaboratorRepositoryEF _collaboratorRepository;
        private readonly ITechnologyRepositoryEF _technologyRepository;

        public SpecialityFactory(ISpecialityRepositoryEF specialityRepository, ICollaboratorRepositoryEF collaboratorRepository, ITechnologyRepositoryEF technologyRepository)
        {
            _specialityRepository = specialityRepository;
            _collaboratorRepository = collaboratorRepository;
            _technologyRepository = technologyRepository;
        }

        public ISpeciality Create(Guid id, string description, Guid technologyId, Guid collaboratorId, PeriodDate periodDate)
        {
            return new Speciality(id, description, technologyId, collaboratorId, periodDate);
        }

        public async Task<ISpeciality> Create(string description, Guid technologyId, Guid collaboratorId, PeriodDate periodDate)
        {

            var collaborator = await _collaboratorRepository.GetByIdAsync(collaboratorId);
            if (collaborator == null) throw new Exception("Collaborator not found");

            var technologyisRepeated = await _technologyRepository.IsRepeated(technologyId);
            if (!technologyisRepeated) throw new Exception("Technology not found");

            return new Speciality(description, technologyId, collaboratorId, periodDate);
        }

        public ISpeciality Create(ISpecialityVisitor visitor)
        {
            return new Speciality(visitor.Id, visitor.Description, visitor.TechnologyId, visitor.CollaboratorId, visitor.PeriodDate);
        }

        /* public ISpeciality ConvertFromTemp(ISpecialityTemporary specialityTemporary, Guid technologyId)
        {
            return new Speciality(specialityTemporary.Id, technologyId, specialityTemporary.description, specialityTemporary.CollaboratorId, specialityTemporary.PeriodDate);
        } */
    }
}

