using MassTransit;
using Application.Interfaces;
using Domain.Models;
using Domain.Messages;

namespace InterfaceAdapters.Consumers
{
    public class SpecialityUpdatedConsumer : IConsumer<SpecialityUpdatedMessage>
    {
        private readonly ISpecialityService _specialityService;

        public SpecialityUpdatedConsumer(ISpecialityService specialityService)
        {
            _specialityService = specialityService;
        }

        public async Task Consume(ConsumeContext<SpecialityUpdatedMessage> context)
        {
            Console.WriteLine("Consome a msg SpecialityUpdatedConsumer");

            var msg = context.Message;

            var speciality = new Speciality(
                msg.SpecialityId,
                msg.Description,
                msg.TechnologyId,
                msg.CollaboratorId,
                msg.PeriodDate
            );

            // Envia a entidade diretamente para ser atualizada
            await _specialityService.SubmitUpdateAsync(speciality);
        }
    }
}
