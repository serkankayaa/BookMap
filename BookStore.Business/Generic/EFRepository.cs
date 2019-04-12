using BookStore.Entity.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookStore.Business.Generic
{
    public class EFRepository<T> : IEFRepository<T> where T : class
    {
        private BookDbContext _context;

        public EFRepository(BookDbContext context)
        {
            _context = context;
        }

        public virtual void Add(T t)
        {
            _context.Set<T>().Add(t);
        }

        public int Count()
        {
            return _context.Set<T>().Count();
        }

        public async Task<int> CountAsync()
        {
            return await _context.Set<T>().CountAsync();
        }

        public virtual void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public virtual T Find(Expression<Func<T, bool>> match)
        {
            return _context.Set<T>().FirstOrDefault(match); 
        }

        public virtual async Task<T> FindAsync(Expression<Func<T, bool>> match)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(match);
        }

        public IQueryable<T> FindAll(Expression<Func<T, bool>> match)
        {
            return _context.Set<T>().Where(match);
        }

        public async Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match)
        {
            return await _context.Set<T>().Where(match).ToListAsync();
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public virtual async Task<ICollection<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public T GetById(Guid id)
        {
            return _context.Set<T>().Find(id);
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual void Save()
        {
            _context.SaveChanges();
        }

        public virtual async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public virtual void Update(T t, object key)
        {
            if (t == null)
                return;

            T existObject = _context.Set<T>().Find(key);
            if (existObject != null)
            {
                _context.Entry(existObject).CurrentValues.SetValues(t);
            }
        }
    }
}
