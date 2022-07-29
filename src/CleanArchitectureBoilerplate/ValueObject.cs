namespace CleanArchitectureBoilerplate
{
    /// <summary>
    /// The base class to represent an immutable domain object that has no identity.
    /// </summary>
    public abstract class ValueObject : IEquatable<ValueObject>
    {
        public override bool Equals(object? obj)
        {
            return Equals(obj as ValueObject);
        }

        public bool Equals(ValueObject? other)
        {
            if (other is null || GetType() != other.GetType())
            {
                return false;
            }

            return GetEqualityComponents()
                .SequenceEqual(other.GetEqualityComponents());
        }

        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Select(c => c != null ? c.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
        }

        public static bool operator ==(ValueObject? left, ValueObject? right)
        {
            if (left is null)
            {
                return right is null;
            }

            return left.Equals(right);
        }

        public static bool operator !=(ValueObject? left, ValueObject? right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Creates a new instance 
        /// </summary>
        /// <returns>A new reference </returns>
        public ValueObject Clone() => (ValueObject)MemberwiseClone();

        /// <summary>
        /// Gets the attributes that will be used to determine its equality.
        /// </summary>
        /// <returns>The collection of values used to determine equality.</returns>
        protected abstract IEnumerable<object?> GetEqualityComponents();
    }
}