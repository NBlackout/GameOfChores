using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using AutoFixture.Xunit2;
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
            Exception exception = Act();

            exception = SerializeAndDeserialize(exception);
            exception.Should().BeOfType<ChoreTypeAlreadyExistsException>();

            ChoreTypeAlreadyExistsException SerializeAndDeserialize(Exception ex)
            {
                BinaryFormatter bf = new BinaryFormatter();
                using MemoryStream ms = new MemoryStream();
                bf.Serialize(ms, ex);
                ms.Seek(0, 0);

                return (ChoreTypeAlreadyExistsException)bf.Deserialize(ms);
            }
        }

        private static ChoreTypeAlreadyExistsException Act() => new ChoreTypeAlreadyExistsException();
    }
}
