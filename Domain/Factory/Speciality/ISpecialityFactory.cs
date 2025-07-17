using System;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Visitors;

namespace Domain.Interfaces
{
    public interface ISpecialityFactory
    {
        ISpeciality Create(Guid id, string description, Guid technologyId, Guid collaboratorId, PeriodDate periodDate);

        Task<ISpeciality> Create(string description, Guid technologyId, Guid collaboratorId, PeriodDate periodDate);

        ISpeciality Create(ISpecialityVisitor visitor);

        // ISpeciality ConvertFromTemp(ISpecialityTemporary specialityTemporary, Guid technologyId);
    }
}
