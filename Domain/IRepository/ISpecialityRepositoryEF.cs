using System;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Domain.IRepository
{
    public interface ISpecialityRepositoryEF
    {
        Task<ISpeciality> AddSpecialityAsync(ISpeciality speciality);

        Task<ISpeciality?> GetSpecialityByIdAsync(Guid id);

        Task<ISpeciality?> UpdateSpecialityAsync(ISpeciality speciality);
    }
}
