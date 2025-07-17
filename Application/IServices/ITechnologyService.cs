using System;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Application.Interfaces
{
    public interface ITechnologyService
    {
        Task<ITechnology> SubmitTechnologyAsync(Guid techId, string description);
    }
}
