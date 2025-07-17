using Application.IPublishers;
using Contracts.Messages;
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

        public Task PublishSpecialityCreatedAsync(Guid id, string description, Guid technologyId, Guid collaboratorId, PeriodDate periodDate)
        {
            var eventMessage = new SpecialityCreatedMessage(id, description, technologyId, collaboratorId, periodDate);
            return _publishEndpoint.Publish(eventMessage);
        }

        public Task PublishSpecialityUpdatedAsync(Guid id, string description, Guid technologyId, Guid collaboratorId, PeriodDate periodDate)
        {
            var eventMessage = new SpecialityUpdatedMessage(id, description, technologyId, collaboratorId, periodDate);
            return _publishEndpoint.Publish(eventMessage);
        }

        /* public async Task SagaCommandAsync(CreateRequestedSaga saga)
        {
            var endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri($"queue:speciality-cmd-saga-{InstanceInfo.InstanceId}"));
            await endpoint.Send(saga);
        } */
    }
}