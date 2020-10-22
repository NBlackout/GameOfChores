using System;
using AutoFixture.Kernel;

namespace GameOfChores.UnitTest.Tools.AutoFixture.Specimens
{
    public abstract class CustomSpecimenBuilder<T> : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            if (!CanCreate())
                return new NoSpecimen();

            T specimen = CreateSpecimen(request, context);
            return SpecimenOrDefault();

            bool CanCreate() => request as Type == typeof(T);

            object SpecimenOrDefault()
            {
                if (specimen == null)
                    return new NoSpecimen();

                return specimen;
            }
        }

        protected abstract T CreateSpecimen(object request, ISpecimenContext context);
    }
}
