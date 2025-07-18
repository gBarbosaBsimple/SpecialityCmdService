using Application.IPublishers;
using Domain.Messages;
using Domain.Models;
using MassTransit;

namespace InterfaceAdapters.Publisher
{

    public class MassTransitPublisher : IMessagePublisher
    {

        private readonly IPublishEndpoint _publishEndpoint;
        private readonly ISendEndpointProvider _sendEndpointProvider;

        public MassTransitPublisher(IPublishEndpoint publishEndpoint, ISendEndpointProvider sendEndpointProvider)
        {
            _publishEndpoint = publishEndpoint;
            _sendEndpointProvider = sendEndpointProvider;
        }

        public Task PublishSpecialityCreatedAsync(Guid SpecialityId, string Description, Guid TechnologyId, Guid CollaboratorId, PeriodDate PeriodDate)
        {
            var eventMessage = new SpecialityCreatedMessage(SpecialityId, Description, TechnologyId, CollaboratorId, PeriodDate);
            return _publishEndpoint.Publish(eventMessage);
        }

        public Task PublishSpecialityUpdatedAsync(Guid SpecialityId, string Description, Guid TechnologyId, Guid CollaboratorId, PeriodDate PeriodDate)
        {
            var eventMessage = new SpecialityUpdatedMessage(SpecialityId, Description, TechnologyId, CollaboratorId, PeriodDate);
            return _publishEndpoint.Publish(eventMessage);
        }

        /* public async Task SagaCommandAsync(CreateRequestedSaga saga)
        {
            var endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri($"queue:speciality-cmd-saga-{InstanceInfo.InstanceId}"));
            await endpoint.Send(saga);
        } */
    }
}