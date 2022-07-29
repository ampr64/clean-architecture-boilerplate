namespace CleanArchitectureBoilerplate
{
    /// <summary>
    /// The base class to represent an entity.
    /// </summary>
    /// <typeparam name="TId">The id type of this entity.</typeparam>
    public abstract class Entity<TId> : IHasDomainEvent, IEquatable<Entity<TId>>
        where TId : notnull, IEquatable<TId>
    {
        private int? _hashCode;

        /// <summary>
        /// Gets the identifier of the entity.
        /// </summary>
        public TId Id { get; protected set; } = default!;

        private readonly List<DomainEvent> _domainEvents = new();
        
        /// <summary>
        /// The domain events of the entity.
        /// </summary>
        public IReadOnlyList<DomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        /// <summary>
        /// Raises a domain event to notify other entities of this occurrence.
        /// </summary>
        /// <param name="domainEvent">The domain event.</param>
        protected void RaiseDomainEvent(DomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        /// <summary>
        /// Indicates whether the entity has been persisted.
        /// </summary>
        protected bool IsTransient => Id?.Equals(default) ?? true;

        public override bool Equals(object? obj)
        {
            return Equals(obj as Entity<TId>);
        }

        public bool Equals(Entity<TId>? other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (GetType() != other.GetType())
            {
                return false;
            }

            if (IsTransient || other.IsTransient)
            {
                return false;
            }

            return Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            if (IsTransient)
            {
                return base.GetHashCode();
            }

            _hashCode ??= Id.GetHashCode() ^ 31;
            return _hashCode.Value;
        }

        public static bool operator ==(Entity<TId>? left, Entity<TId>? right)
        {
            if (left is null)
            {
                return right is null;
            }

            return left.Equals(right);
        }

        public static bool operator !=(Entity<TId>? left, Entity<TId>? right)
        {
            return !(left == right);
        }
    }
}