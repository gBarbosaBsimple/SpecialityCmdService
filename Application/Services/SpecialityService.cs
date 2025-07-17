using Application.DTO.Speciality;
using Application.Interfaces;
using Application.IPublishers;
using Domain.Factory.SpecialityFactory;
using Domain.Interfaces;
using Domain.IRepository;
using Domain.Models;
namespace Application.Services
{
    public class SpecialityService : ISpecialityService
    {
        private readonly ISpecialityRepositoryEF _specialityRepository;
        private readonly ISpecialityFactory _specialityFactory;
        private readonly ITechnologyRepositoryEF _technologyRepository;
        private readonly ICollaboratorRepositoryEF _collaboratorRepository;
        private readonly IMessagePublisher _publisher;

        public SpecialityService(ISpecialityRepositoryEF specialityRepository, ISpecialityFactory specialityFactory, IMessagePublisher publisher, ITechnologyRepositoryEF technologyRepository, ICollaboratorRepositoryEF collaboratorRepository)
        {
            _specialityRepository = specialityRepository;
            _specialityFactory = specialityFactory;
            _publisher = publisher;
            _technologyRepository = technologyRepository;
            _collaboratorRepository = collaboratorRepository;
        }

        public async Task<Result<SpecialityAddedDTO>> Create(AddSpecialityDTO addSpecialityDTO)
        {
            ISpeciality speciality;
            try
            {
                Console.WriteLine("[DEBUG] Antes de criar a Speciality");

                // Criar visitor e passar à factory
                var visitor = new Speciality(
                    addSpecialityDTO.Description,
                    addSpecialityDTO.TechnologyId,
                    addSpecialityDTO.CollaboratorId,
                    addSpecialityDTO.PeriodDate
                );

                speciality = _specialityFactory.Create(visitor.CollaboratorId, visitor.Description, visitor.TechnologyId, visitor.CollaboratorId, visitor.PeriodDate);

                Console.WriteLine("[DEBUG] depois de criar a Speciality");

                speciality = await _specialityRepository.AddSpecialityAsync(speciality);

                var result = new SpecialityAddedDTO(
                    speciality.Id,
                    speciality.Description,
                    speciality.CollaboratorId,
                    speciality.TechnologyId,
                    speciality.PeriodDate
                );

                await _publisher.PublishSpecialityCreatedAsync(
                    speciality.Id,
                    speciality.Description,
                    speciality.TechnologyId,
                    speciality.CollaboratorId,
                    speciality.PeriodDate
                );

                return Result<SpecialityAddedDTO>.Success(result);
            }
            catch (Exception ex)
            {
                return Result<SpecialityAddedDTO>.Failure(Error.InternalServerError(ex.Message));
            }
        }


        public async Task<Result<UpdatedSpecialityDTO>> Update(UpdateSpecialityDTO dto)
        {
            try
            {
                // Criar Visitor (já tens aqui a entidade ISpeciality com todos os dados atualizados)
                var visitor = new Speciality(
                    dto.Id,
                    dto.Description,
                    dto.TechnologyId,
                    dto.CollaboratorId,
                    dto.PeriodDate
                );

                // Envia diretamente a entidade para update
                var updatedSpeciality = await SubmitUpdateAsync(visitor);

                if (updatedSpeciality == null)
                    return Result<UpdatedSpecialityDTO>.Failure(Error.NotFound("speciality not found"));

                var result = new UpdatedSpecialityDTO(
                    updatedSpeciality.Id,
                    updatedSpeciality.Description,
                    updatedSpeciality.TechnologyId,
                    updatedSpeciality.CollaboratorId,
                    updatedSpeciality.PeriodDate
                );

                await _publisher.PublishSpecialityUpdatedAsync(
                    updatedSpeciality.Id,
                    updatedSpeciality.Description,
                    updatedSpeciality.TechnologyId,
                    updatedSpeciality.CollaboratorId,
                    updatedSpeciality.PeriodDate
                );

                return Result<UpdatedSpecialityDTO>.Success(result);
            }
            catch (Exception ex)
            {
                return Result<UpdatedSpecialityDTO>.Failure(Error.InternalServerError(ex.Message));
            }
        }



        public async Task<ISpeciality> SubmitAsyncsync(Guid id, string description, Guid collaboratorId, Guid technologyId, PeriodDate periodDate)
        {
            var specialityexists = await _specialityRepository.GetSpecialityByIdAsync(id);
            if (specialityexists != null) return specialityexists;

            var speciality = _specialityFactory.Create(id, description, technologyId, collaboratorId, periodDate);
            return await _specialityRepository.AddSpecialityAsync(speciality);
        }

        public async Task<ISpeciality?> SubmitUpdateAsync(ISpeciality speciality)
        {
            return await _specialityRepository.UpdateSpecialityAsync(speciality);
        }


    }
}