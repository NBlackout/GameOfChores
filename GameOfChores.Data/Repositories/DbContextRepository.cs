using System;

namespace GameOfChores.Data.Repositories
{
    public abstract class DbContextRepository : IDisposable
    {
        private bool disposed;

        public GameOfChoresContext Context { get; }

        protected DbContextRepository(GameOfChoresContext context)
        {
            Context = context;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
                Context.Dispose();

            disposed = true;
        }
    }
}
