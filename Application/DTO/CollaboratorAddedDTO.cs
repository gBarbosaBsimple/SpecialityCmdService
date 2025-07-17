using Domain.Models;

namespace Application.DTO.Collaborator
{
    public record CollaboratorAddedDTO
    {
        public Guid Id { get; }
        public PeriodDateTime PeriodDate { get; }
        public CollaboratorAddedDTO(Guid guid, PeriodDateTime periodDate)
        {
            this.Id = guid;
            this.PeriodDate = periodDate;
        }
        public CollaboratorAddedDTO() { }
    }
}