using Domain.Interfaces;
using Domain.Models;

namespace Application.DTO.Speciality;

public record AddSpecialityDTO
{
    public string Description { get; init; }
    public Guid TechnologyId { get; init; }
    public Guid CollaboratorId { get; init; }
    public PeriodDate PeriodDate { get; init; }

    public AddSpecialityDTO(string description, Guid technologyId, Guid collaboratorId, PeriodDate periodDate)
    {
        this.Description = description;
        this.TechnologyId = technologyId;
        this.CollaboratorId = collaboratorId;
        this.PeriodDate = periodDate;
    }

    public AddSpecialityDTO() { }
}