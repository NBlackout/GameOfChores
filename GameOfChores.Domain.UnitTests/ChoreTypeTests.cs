﻿using System;
using AutoFixture.Xunit2;
using FluentAssertions;
using Xunit;

namespace GameOfChores.Domain.UnitTests
{
    public class ChoreTypeTests
    {
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
            ChoreType chore = Act(label);

            chore.Label.Should().Be(label);
        }

        private static ChoreType Act(string label) => new ChoreType(label);
    }
}