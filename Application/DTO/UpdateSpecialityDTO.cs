using Domain.Interfaces;
using Domain.Models;

namespace Application.DTO.Speciality;

public record UpdateSpecialityDTO
{
    public Guid Id { get; init; }
    public string Description { get; init; }
    public Guid TechnologyId { get; init; }
    public Guid CollaboratorId { get; init; }
    public PeriodDate PeriodDate { get; init; }

    public UpdateSpecialityDTO(Guid id, string description, Guid technologyId, Guid collaboratorId, PeriodDate periodDate)
    {
        this.Id = id;
        this.Description = description;
        this.TechnologyId = technologyId;
        this.CollaboratorId = collaboratorId;
        this.PeriodDate = periodDate;
    }

    public UpdateSpecialityDTO() { }
}