namespace GameOfChores.Data.Repositories
{
    public abstract class DbContextRepository
    {
        public GameOfChoresContext Context { get; }

        protected DbContextRepository(GameOfChoresContext context)
        {
            Context = context;
        }
    }
}
