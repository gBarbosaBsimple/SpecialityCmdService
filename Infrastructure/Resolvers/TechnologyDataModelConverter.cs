using AutoMapper;
using Domain.Factory.TechnologyFactory;
using Domain.Interfaces;
using Infrastructure.DataModel;

namespace Infrastructure.Resolvers
{
    public class TechnologyDataModelConverter : ITypeConverter<TechnologyDataModel, ITechnology>
    {
        private readonly ITechnologyFactory _factory;

        public TechnologyDataModelConverter(ITechnologyFactory factory)
        {
            _factory = factory;
        }

        public ITechnology Convert(TechnologyDataModel source, ITechnology destination, ResolutionContext context)
        {
            return _factory.Create(source);
        }
    }
}