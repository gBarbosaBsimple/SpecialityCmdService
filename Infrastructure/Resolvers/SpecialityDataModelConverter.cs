using AutoMapper;
using Domain.Factory;
using Domain.Factory.SpecialityFactory;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.DataModel;

namespace Infrastructure.Resolvers
{
    public class SpecialityDataModelConverter : ITypeConverter<SpecialityDataModel, ISpeciality>
    {
        private readonly ISpecialityFactory _factory;

        public SpecialityDataModelConverter(ISpecialityFactory factory)
        {
            _factory = factory;
        }

        public ISpeciality Convert(SpecialityDataModel source, ISpeciality destination, ResolutionContext context)
        {
            return _factory.Create(source);
        }
    }
}