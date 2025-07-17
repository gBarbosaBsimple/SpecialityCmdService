using AutoMapper;
using Domain.Factory.CollaboratorFactory;
using Domain.Interfaces;
using Infrastructure.DataModel;

namespace Infrastructure.Resolvers
{
    public class CollaboratorDataModelConverter : ITypeConverter<CollaboratorDataModel, ICollaborator>
    {
        private readonly ICollaboratorFactory _collaboratorFactory;

        public CollaboratorDataModelConverter(ICollaboratorFactory collaboratorFactory)
        {
            _collaboratorFactory = collaboratorFactory;
        }

        public ICollaborator Convert(CollaboratorDataModel source, ICollaborator destination, ResolutionContext context)
        {
            return _collaboratorFactory.Create(source);
        }
    }
}