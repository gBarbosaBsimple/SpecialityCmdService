using Application.Interfaces;
using Domain.Factory.TechnologyFactory;
using Domain.Interfaces;
using Domain.IRepository;

namespace Application.Services
{
    public class TechnologyService : ITechnologyService
    {
        private readonly ITechnologyRepositoryEF _technologyRepository;
        private readonly ITechnologyFactory _technologyFactory;

        public TechnologyService(ITechnologyRepositoryEF technologyRepository, ITechnologyFactory TechnologyFactory)
        {
            _technologyRepository = technologyRepository;
            _technologyFactory = TechnologyFactory;
        }

        public async Task<ITechnology> SubmitTechnologyAsync(Guid techId, string description)
        {
            var tech = _technologyFactory.Create(techId, description);

            return await _technologyRepository.AddTechnologyAsync(tech);
        }
    }
}