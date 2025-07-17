using Application.Interfaces;
using Contracts.Messages;
using MassTransit;

namespace InterfaceAdapters.Consumers
{

    public class TechnologyCreatedConsumer : IConsumer<TechnologyCreatedMessage>
    {
        private readonly ITechnologyService _technologyService;

        public TechnologyCreatedConsumer(ITechnologyService technologyService)
        {
            _technologyService = technologyService;
        }

        public Task Consume(ConsumeContext<TechnologyCreatedMessage> context)
        {
            var techId = context.Message.Id;
            var description = context.Message.Description;
            return _technologyService.SubmitTechnologyAsync(techId, description);
        }
    }
}