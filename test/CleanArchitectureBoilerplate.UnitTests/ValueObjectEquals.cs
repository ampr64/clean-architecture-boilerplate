namespace CleanArchitectureBoilerplate.UnitTests
{
    public class ValueObjectEquals
    {
        [Theory, AutoMoqData]
        public void Equals_ShouldReturnTrue_WhenBothHaveSameTypeAndValues(string value1, int value2)
        {
            var valueObjectA = new DummyValueObject(value1, value2);
            var valueObjectB = new DummyValueObject(value1, value2);

            var actual = valueObjectA.Equals(valueObjectB);

            actual.Should().BeTrue();
        }

        [Theory, AutoMoqData]
        public void EqualsObj_ShouldReturnTrue_WhenBothHaveSameTypeAndValues(string value1, int value2)
        {
            var valueObjectA = new DummyValueObject(value1, value2);
            object valueObjectB = new DummyValueObject(value1, value2);

            var actual = valueObjectA.Equals(valueObjectB);

            actual.Should().BeTrue();
        }

        [Theory, AutoMoqData]
        public void Equals_ShouldReturnFalse_WhenTypesDiffer(string value1, int value2)
        {
            var valueObjectA = new DummyValueObject(value1, value2);
            var valueObjectB = new DummyValueObject2(value1, value2);

            var actual = valueObjectA.Equals(valueObjectB);

            actual.Should().BeFalse();
        }

        [Theory, AutoMoqData]
        public void Equals_ShouldReturnFalse_WhenOtherIsNull(string value1, int value2)
        {
            var valueObjectA = new DummyValueObject(value1, value2);
            DummyValueObject? valueObjectB = null;

            var actual = valueObjectA.Equals(valueObjectB);

            actual.Should().BeFalse();
        }

        [Fact]
        public void EqualOperator_ShouldReturnTrue_WhenBothAreNull()
        {
            ValueObject? valueObjectA = null;
            ValueObject? valueObjectB = null;

            var actual = valueObjectA == valueObjectB;

            actual.Should().BeTrue();
        }

        [Theory, AutoMoqData]
        public void NotEqualOperator_ShouldReturnOppositeOfEqualOperator(string value1, int value2)
        {
            var valueObjectA = new DummyValueObject(value1, value2);
            var valueObjectB = new DummyValueObject(value1, value2);

            var equals = valueObjectA == valueObjectB;
            var actual = valueObjectA != valueObjectB;

            actual.Should().NotBe(equals);
        }
    }
}