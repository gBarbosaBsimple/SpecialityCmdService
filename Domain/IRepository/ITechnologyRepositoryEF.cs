using System;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Domain.IRepository
{
    public interface ITechnologyRepositoryEF
    {
        Task<bool> IsRepeated(Guid id);

        Task<ITechnology> AddTechnologyAsync(ITechnology technology);
    }
}
