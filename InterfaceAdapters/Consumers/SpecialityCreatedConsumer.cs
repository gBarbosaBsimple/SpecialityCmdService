using Contracts.Messages;
using MassTransit;
using Application.Interfaces;
using Domain.Models;
using Domain.Messages;

namespace InterfaceAdapters.Consumers
{

    public class SpecialityCreatedConsumer : IConsumer<SpecialityCreatedMessage>
    {
        private readonly ISpecialityService _specialityService;

        public SpecialityCreatedConsumer(ISpecialityService specialityService)
        {
            _specialityService = specialityService;
        }

        public async Task Consume(ConsumeContext<SpecialityCreatedMessage> context)
        {
            Console.WriteLine("consome a msg specialitycreatedconsumer");
            await _specialityService.SubmitAsyncsync(context.Message.SpecialityId, context.Message.Description, context.Message.CollaboratorId, context.Message.TechnologyId, context.Message.PeriodDate);
        }
    }
}