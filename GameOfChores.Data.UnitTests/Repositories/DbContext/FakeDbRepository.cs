using GameOfChores.Data.Repositories;

namespace GameOfChores.Data.UnitTests.Repositories.DbContext
{
    public class FakeDbRepository : DbContextRepository
    {
        public FakeDbRepository(GameOfChoresContext context)
            : base(context)
        {
        }
    }
}
