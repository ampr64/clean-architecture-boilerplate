namespace CleanArchitectureBoilerplate.UnitTests
{
    public class EntityGetHashCode
    {
        [Theory, AutoMoqData]
        public void GetHashCode_ShouldReturnSameValue_GivenEqualEntities(int id)
        {
            var entityA = new DummyEntityIntId(id);
            var entityB = new DummyEntityIntId(id);

            var hashCodeA = entityA.GetHashCode();
            var hashCodeB = entityB.GetHashCode();

            entityB.Equals(entityA).Should().BeTrue();
            hashCodeB.Should().Be(hashCodeA);
        }

        [Fact]
        public void GetHashCode_ShouldReturnDifferentValue_GivenDifferentEntities()
        {
            var entityA = new DummyEntityIntId(1);
            var entityB = new DummyEntityIntId(2);

            var hashCodeA = entityA.GetHashCode();
            var hashCodeB = entityB.GetHashCode();

            entityB.Equals(entityA).Should().BeFalse();
            hashCodeB.Should().NotBe(hashCodeA);
        }
    }
}