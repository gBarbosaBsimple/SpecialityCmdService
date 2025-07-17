using System;
using System.Threading.Tasks;
using Domain.Interfaces;
using Application.DTO.Speciality;
using Domain.Models;

namespace Application.Interfaces
{
    public interface ISpecialityService
    {
        Task<Result<SpecialityAddedDTO>> Create(AddSpecialityDTO addSpecialityDTO);

        Task<Result<UpdatedSpecialityDTO>> Update(UpdateSpecialityDTO dto);

        Task<ISpeciality> SubmitAsyncsync(Guid id, string description, Guid collaboratorId, Guid technologyId, PeriodDate periodDate);

        Task<ISpeciality?> SubmitUpdateAsync(ISpeciality speciality);
    }
}
