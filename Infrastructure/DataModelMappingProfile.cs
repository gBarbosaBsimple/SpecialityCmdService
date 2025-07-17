using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.DataModel;
using Infrastructure.Resolvers;

namespace Infrastructure
{

    public class DataModelMappingProfile : Profile
    {
        public DataModelMappingProfile()
        {
            CreateMap<Technology, TechnologyDataModel>();
            CreateMap<TechnologyDataModel, ITechnology>()
                .ConvertUsing<TechnologyDataModelConverter>();
            CreateMap<Collaborator, CollaboratorDataModel>();
            CreateMap<CollaboratorDataModel, ICollaborator>()
                .ConvertUsing<CollaboratorDataModelConverter>();
            CreateMap<Speciality, SpecialityDataModel>();
            CreateMap<SpecialityDataModel, ISpeciality>()
                .ConvertUsing<SpecialityDataModelConverter>();
        }

    }
}