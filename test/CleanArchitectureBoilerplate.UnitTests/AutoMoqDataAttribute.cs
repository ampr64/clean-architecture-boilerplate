using AutoFixture.AutoMoq;

namespace CleanArchitectureBoilerplate.UnitTests
{
    public class AutoMoqDataAttribute : AutoDataAttribute
    {
        public AutoMoqDataAttribute() : base(() =>
        {
            var fixture = new Fixture();
            fixture.Customize(new AutoMoqCustomization { ConfigureMembers = true });

            return fixture;
        })
        {
        }
    }
}