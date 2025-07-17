namespace Domain.Visitors;

public interface ITechnologyVisitor
{
    public Guid Id { get; }
    public string Description { get; }
}