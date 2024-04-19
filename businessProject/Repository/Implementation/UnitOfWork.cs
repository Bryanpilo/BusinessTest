using businessProject.Models;
using businessProject.Repository.Interface;

namespace businessProject.Repository.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BusinessProjectContext _context;
        public UnitOfWork(BusinessProjectContext context)
        {
            _context = context;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
                if (disposing)
                    _context.Dispose();
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}