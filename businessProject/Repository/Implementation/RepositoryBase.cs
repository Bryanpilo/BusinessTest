using System.Linq.Expressions;
using businessProject.Models;
using businessProject.Repository.Interface;

namespace businessProject.Repository.Implementation
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        
        protected readonly BusinessProjectContext _context;

        public RepositoryBase(BusinessProjectContext context)
        {
            _context = context;

        }
        public virtual void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }
        public virtual void AddRange(List<T> entity)
        {
            _context.Set<T>().AddRange(entity);
        }

        public virtual bool Exist(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Any(predicate);
        }

        public virtual IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsEnumerable();
        }

        public virtual IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).AsEnumerable();
        }
        public virtual T GetSingle(Expression<Func<T, bool>> predicate)
        {
#pragma warning disable CS8603 // Possible null reference return.

            return _context.Set<T>().FirstOrDefault(predicate);
#pragma warning restore CS8603 // Possible null reference return.

        }

        public virtual void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public virtual void DeleteWhere(Expression<Func<T, bool>> predicate)
        {
            var data = _context.Set<T>().Where(predicate).ToList();
            _context.Set<T>().RemoveRange(data);
        }
    }
}