namespace CleanArchitectureBoilerplate
{
    /// <summary>
    /// Defines a type that has a collection of domain events. 
    /// </summary>
    public interface IHasDomainEvent
    {
        /// <summary>
        /// A read-only collection of <see cref="DomainEvent"/>.
        /// </summary>
        IReadOnlyList<DomainEvent> DomainEvents { get; }

        /// <summary>
        /// Clears all current domain events.
        /// </summary>
        void ClearDomainEvents();
    }
}