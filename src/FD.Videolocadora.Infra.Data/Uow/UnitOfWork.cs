using FD.Videolocadora.Infra.Data.Context;
using FD.Videolocadora.Infra.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        public void Commit()
        {
            _context.SaveChanges();
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
