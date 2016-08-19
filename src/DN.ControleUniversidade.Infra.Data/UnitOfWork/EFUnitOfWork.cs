using DN.ControleUniversidade.Infra.Data.Context;
using DN.ControleUniversidade.Infra.Data.Interfaces;
using System;

namespace DN.ControleUniversidade.Infra.Data.UnitOfWork
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly UniversidadeContext _dbContext;
        private bool _disposed;

        public EFUnitOfWork(UniversidadeContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void BeginTransaction()
        {
            _disposed = false;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
