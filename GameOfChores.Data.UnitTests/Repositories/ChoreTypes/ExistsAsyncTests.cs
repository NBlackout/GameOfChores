﻿using System.Threading.Tasks;
using FluentAssertions;
using GameOfChores.Data.Entities;
using GameOfChores.Data.Repositories;
using GameOfChores.Domain;
using GameOfChores.UnitTest.Tools.AutoFixture;
using Xunit;

namespace GameOfChores.Data.UnitTests.Repositories.ChoreTypes
{
    public class ExistsAsyncTests : InMemoryRepositoryTests
    {
        private readonly ChoreTypeRepository repository;

        public ExistsAsyncTests()
        {
            repository = new ChoreTypeRepository(Context);
        }

        [Theory, ExtendedAutoData]
        public async Task NotExistingChoreType_GivesFalse(ChoreType choreType)
        {
            bool exists = await ActAsync(choreType);

            exists.Should().BeFalse();
        }

        [Theory, ExtendedAutoData]
        public async Task ExistingChoreType_GivesTrue(ChoreType choreType)
        {
            await using (GameOfChoresContext context = MakeDbContext())
            {
                await context.ChoreTypes.AddAsync(new ChoreTypeEntity { Id = 1, Label = choreType.Label.ToUpperInvariant() });
                await context.SaveChangesAsync();
            }

            bool exists = await ActAsync(choreType);

            exists.Should().BeTrue();
        }

        private async Task<bool> ActAsync(ChoreType choreType) => await repository.ExistsAsync(choreType);
    }
}
