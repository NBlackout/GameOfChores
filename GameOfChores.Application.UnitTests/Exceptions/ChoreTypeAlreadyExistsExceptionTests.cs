using System;
using System.Text.Json;
using FluentAssertions;
using GameOfChores.Application.Exceptions;
using Xunit;

namespace GameOfChores.Application.UnitTests.Exceptions
{
    public class ChoreTypeAlreadyExistsExceptionTests
    {
        [Fact]
        public void Toto()
        {
            var exception = new ChoreTypeAlreadyExistsException();
            string json = JsonSerializer.Serialize(exception);

            Func<ChoreTypeAlreadyExistsException> act = () => Act(json);

            act.Should().NotThrow();
        }

        private static ChoreTypeAlreadyExistsException Act(string json) => JsonSerializer.Deserialize<ChoreTypeAlreadyExistsException>(json)!;
    }
}
