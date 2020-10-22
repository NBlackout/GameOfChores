using AutoFixture;
using AutoFixture.Kernel;
using GameOfChores.Domain;

namespace GameOfChores.UnitTest.Tools.AutoFixture.Specimens.Domain
{
    public class ChoreTypeBuilder : CustomSpecimenBuilder<ChoreType>
    {
        protected override ChoreType CreateSpecimen(object request, ISpecimenContext context)
        {
            var label = context.Create<string>();

            return new ChoreType(label);
        }
    }
}
