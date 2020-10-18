using AutoFixture;
using AutoFixture.Kernel;
using GameOfChores.Domain;

namespace GameOfChores.UnitTest.Tools.AutoFixture.Specimens.Domain
{
    public class ChoreBuilder : CustomSpecimenBuilder<Chore>
    {
        protected override Chore CreateSpecimen(object request, ISpecimenContext context)
        {
            var label = context.Create<string>();

            return new Chore(label);
        }
    }
}
