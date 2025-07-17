namespace Application.DTO.Technology
{

    public record TechnologyAddedDTO
    {
        public Guid Id { get; }
        public TechnologyAddedDTO(Guid id)
        {
            this.Id = id;
        }
        public TechnologyAddedDTO() { }
    }
}