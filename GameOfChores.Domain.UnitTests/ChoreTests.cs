using System;
using AutoFixture.Xunit2;
using FluentAssertions;
using Xunit;

namespace GameOfChores.Domain.UnitTests
{
    public class ChoreTests
    {
        [Fact]
        public void NoLabel_GivesError()
        {
            Action nullLabelAction = () => Act(null);

            nullLabelAction.Should().ThrowExactly<ArgumentNullException>()
                .And.ParamName.Should().BeEquivalentTo("Label");
        }

        [Theory]
        [InlineData("")]
        [InlineData("\t ")]
        public void InvalidLabel_GivesError(string label)
        {
            Action act = () => Act(label);

            act.Should().ThrowExactly<ArgumentException>().WithMessage("Label should not be empty");
        }

        [Theory, AutoData]
        public void ValidLabel_SetsBackingMember(string label)
        {
            Chore chore = Act(label);

            chore.Label.Should().Be(label);
        }

        private static Chore Act(string label) => new Chore(label);
    }
}
