using FD.Videolocadora.Infra.Data.Context;
using FD.Videolocadora.Infra.Data.Interface;

namespace FD.Videolocadora.Infra.Data.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VideolocadoraContext _context;
        private bool _disposed;
        public UnitOfWork(VideolocadoraContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _disposed = false;
            _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _context.SaveChanges();

        }

        public void Rollback()
        {
            _context.Database.CurrentTransaction.Rollback();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
        }
        public void Dispose()
        {
            Dispose(true);
        }
    }
}
