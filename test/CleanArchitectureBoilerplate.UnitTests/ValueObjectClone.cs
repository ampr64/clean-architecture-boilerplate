namespace CleanArchitectureBoilerplate.UnitTests
{
    public class ValueObjectClone
    {
        [Theory, AutoMoqData]
        public void Clone_ShouldReturnEquivalentValueObject(string value1, int value2)
        {
            var valueObject = new DummyValueObject(value1, value2);
            var clone = valueObject.Clone();

            clone.Should().Be(valueObject);
        }
    }
}