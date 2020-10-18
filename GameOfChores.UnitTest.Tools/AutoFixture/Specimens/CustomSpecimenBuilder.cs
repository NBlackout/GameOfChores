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

            return CreateSpecimen(request, context);

            bool CanCreate() => request as Type == typeof(T);
        }

        protected abstract T CreateSpecimen(object request, ISpecimenContext context);
    }
}
