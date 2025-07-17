namespace Application.DTO.Technology
{
    public record TechnologyDTO
    {
        public Guid Id { get; }
        public string Description { get; set; }
        public TechnologyDTO(Guid id, string description)
        {
            this.Id = id;
            this.Description = description;
        }
        public TechnologyDTO() { }
    }
}