using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Business.Generic
{
    public interface IEFRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        Task<ICollection<T>> GetAllAsync();
        T GetById(Guid id);
        Task<T> GetByIdAsync(Guid id);
        T Find(Expression<Func<T, bool>> match);
        Task<T> FindAsync(Expression<Func<T, bool>> match);
        IQueryable<T> FindAll(Expression<Func<T, bool>> match);
        Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match);
        int Count();
        Task<int> CountAsync();
        void Add(T t);
        void Update(T entity);
        void Delete(T entity);
        void Save();
        Task<int> SaveAsync();
    }
}
