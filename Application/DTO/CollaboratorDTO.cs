using Domain.Models;

namespace Application.DTO.Collaborator;

public record CollaboratorDTO
{
    public Guid Id { get; }
    public PeriodDateTime PeriodDate { get; }
    public CollaboratorDTO(Guid guid, PeriodDateTime periodDate)
    {
        this.Id = guid;
        this.PeriodDate = periodDate;
    }
    public CollaboratorDTO() { }
}