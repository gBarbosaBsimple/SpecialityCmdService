using Domain.Models;

namespace Domain.Messages
{
    public record TechnologyCreatedMessage(Guid Id, string Description);
}