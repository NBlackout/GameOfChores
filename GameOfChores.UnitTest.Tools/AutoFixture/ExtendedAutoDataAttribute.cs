using AutoFixture;
using AutoFixture.Xunit2;
using GameOfChores.UnitTest.Tools.AutoFixture.Specimens.Domain;

namespace GameOfChores.UnitTest.Tools.AutoFixture
{
    public class ExtendedAutoDataAttribute : AutoDataAttribute
    {
        public ExtendedAutoDataAttribute()
            : base(FixtureFactory)
        {
        }

        private static IFixture FixtureFactory() => new Fixture().Customize(new FixtureCustomizer());

        private class FixtureCustomizer : ICustomization
        {
            public void Customize(IFixture fixture)
            {
                fixture.Customizations.Add(new ChoreTypeBuilder());
            }
        }
    }
}
