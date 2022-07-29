namespace CleanArchitectureBoilerplate.UnitTests
{
    public class DummyValueObject : ValueObject
    {
        public string Value1 { get; }

        public int Value2 { get; }

        public DummyValueObject(string value1, int value2)
        {
            Value1 = value1;
            Value2 = value2;
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value1;
            yield return Value2;
        }
    }

    public class DummyValueObject2 : ValueObject
    {
        public string Value1 { get; }

        public int Value2 { get; }

        public DummyValueObject2(string value1, int value2)
        {
            Value1 = value1;
            Value2 = value2;
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value1;
        }
    }
}