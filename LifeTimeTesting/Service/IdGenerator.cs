namespace LifeTimeTesting.Service;

public class IdGenerator : IIdGenerator
{
    public Guid Id { get; } = Guid.NewGuid();
}
