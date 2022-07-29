namespace CleanArchitectureBoilerplate
{
    public interface IHasDomainEvent
    {
        IReadOnlyList<DomainEvent> DomainEvents { get; }

        void ClearDomainEvents();
    }
}