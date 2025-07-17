using Domain.Models;


namespace Application.IPublishers
{
    public interface IMessagePublisher
    {
        Task PublishSpecialityCreatedAsync(Guid id, string description, Guid technologyId, Guid collaboratorId, PeriodDate periodDate);
        Task PublishSpecialityUpdatedAsync(Guid id, string description, Guid technologyId, Guid collaboratorId, PeriodDate periodDate);
        //Task SendCreateSpecialitySagaCommandAsync(CreateRequestedSpecialityCommand command);
    }
}