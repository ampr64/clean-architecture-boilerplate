namespace CleanArchitectureBoilerplate.UnitTests
{
    public class ValueObjectGetHashCode
    {
        [Theory, AutoMoqData]
        public void GetHashCode_ShouldReturnSameValue_GivenSameEqualityComponents(string value1, int value2)
        {
            var valueObjectA = new DummyValueObject(value1, value2);
            var valueObjectB = new DummyValueObject(value1, value2);

            var hashCodeA = valueObjectA.GetHashCode();
            var hashCodeB = valueObjectB.GetHashCode();

            hashCodeA.Should().Be(hashCodeB);
        }

        [Theory]
        [AutoMoqInlineData("test", 10)]
        [AutoMoqInlineData("abc", 123)]
        [AutoMoqInlineData("string", 500)]
        public void GetHashCode_ShouldReturnDifferentValue_GivenDifferentEqualityComponents(string value1, int value2)
        {
            var valueObjectA = new DummyValueObject(value1, value2);
            var valueObjectB = new DummyValueObject2(value1, value2);

            var hashCodeA = valueObjectA.GetHashCode();
            var hashCodeB = valueObjectB.GetHashCode();

            hashCodeA.Should().NotBe(hashCodeB);
        }
    }
}