using Domain.Models;

namespace Application.DTO.Collaborator
{

    public record AddCollaboratorDTO
    {
        public Guid Id { get; }
        public PeriodDateTime PeriodDate { get; }
        public AddCollaboratorDTO() { }

        public AddCollaboratorDTO(Guid guid, PeriodDateTime periodDate)
        {
            this.Id = guid;
            this.PeriodDate = periodDate;
        }
    }
}