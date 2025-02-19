using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace DAL.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        DbSet<T> GetDbSet();
        #region async methods
        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdAsync(long id);
        Task AddAsync(T entity, bool commit = true);
        Task UpdateAsync(T entity, bool commit = true);
        Task RemoveAsync(T entity, bool commit = true);
        Task<IEnumerable<T>> GetAllAsync();
        Task UpdateRangeAsync(IEnumerable<T> entities, bool commit = true);
        Task AddRangeAsync(IEnumerable<T> entities, bool commit = true);
        Task RemoveRangeAsync(IEnumerable<T> entities, bool commit = true);
        Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> predicate);
        #endregion
        #region synchronous methods
        T GetById(long id);
        T GetById(int id);
        T Add(T entity, bool commit = true);
        void Update(T entity, bool commit = true);
        void Remove(T entity, bool commit = true);
        IEnumerable<T> GetAllAsIEnumerable();
        IQueryable<T> GetAllAsIQueryable();
        void UpdateRange(IEnumerable<T> entities, bool commit = true);
        void AddRange(IEnumerable<T> entities, bool commit = true);
        void RemoveRange(IEnumerable<T> entities, bool commit = true);
        IEnumerable<T> GetWhere(Expression<Func<T, bool>> predicate);
        #endregion

        void SaveChanges();
        Task SaveChangesAsync();
    }
}