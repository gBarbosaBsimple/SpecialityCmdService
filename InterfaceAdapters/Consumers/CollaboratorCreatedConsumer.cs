using Application.Interfaces;
using Domain.Models;
using Domain.Messages;
using MassTransit;

namespace InterfaceAdapters.Consumers;

public class CollaboratorCreatedConsumer : IConsumer<CollaboratorCreatedMessage>
{
    private readonly ICollaboratorService _collaboratorService;

    public CollaboratorCreatedConsumer(ICollaboratorService collaboratorService)
    {
        _collaboratorService = collaboratorService;
    }

    public Task Consume(ConsumeContext<CollaboratorCreatedMessage> context)
    {
        Console.WriteLine($"[DEBUG] Received CollaboratorCreatedMessage: {context.Message.Id}");

        var collabId = context.Message.Id;
        return _collaboratorService.SubmitCollaboratorAsync(collabId);
    }
}