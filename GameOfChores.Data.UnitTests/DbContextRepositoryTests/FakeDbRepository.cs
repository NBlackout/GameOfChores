using GameOfChores.Data.Repositories;

namespace GameOfChores.Data.UnitTests.DbContextRepositoryTests
{
    public class FakeDbRepository : DbContextRepository
    {
        public FakeDbRepository(GameOfChoresContext context)
            : base(context)
        {
        }
    }
}
