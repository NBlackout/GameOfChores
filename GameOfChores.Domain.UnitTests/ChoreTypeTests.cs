using System;
using AutoFixture.Xunit2;
using FluentAssertions;
using Xunit;

namespace GameOfChores.Domain.UnitTests
{
    public class ChoreTypeTests
    {
        [Fact]
        public void InvalidGuid_GivesError()
        {
            Action act = () => Act(default, string.Empty);

            act.Should().Throw<ArgumentException>().WithMessage("Chore type guid must not be empty");
        }

        [Theory]
        [InlineData("")]
        [InlineData("\t ")]
        public void InvalidLabel_GivesError(string label)
        {
            Action act = () => Act(Guid.NewGuid(), label);

            act.Should().Throw<ArgumentException>().WithMessage("Chore type label must not be empty");
        }

        [Theory, AutoData]
        public void ValidLabel_SetsBackingMember(Guid guid, string label)
        {
            ChoreType choreType = Act(guid, label);

            choreType.Guid.Should().Be(guid);
            choreType.Label.Should().Be(label);
        }

        private static ChoreType Act(Guid guid, string label) => new ChoreType(guid, label);
    }
}
