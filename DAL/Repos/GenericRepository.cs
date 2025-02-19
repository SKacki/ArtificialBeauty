using System.Linq.Expressions;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repos
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext Context;
        private readonly DbSet<T> _table;
        
        public GenericRepository(AppDbContext context)
        {
            Context = context;
            _table = Context.Set<T>();
        }

        public virtual T Add(T entity, bool commit = true)
        {
            _table.Add(entity);
            if (commit) Context.SaveChanges();
            return entity;
        }
        public virtual async Task AddAsync(T entity, bool commit = true)
        {
            await _table.AddAsync(entity);
            if (commit) await Context.SaveChangesAsync();
        }
        public virtual void AddRange(IEnumerable<T> entities, bool commit = true)
        {
            _table.AddRange(entities);
            Context.SaveChanges();
        }
        public virtual async Task AddRangeAsync(IEnumerable<T> entities, bool commit = true)
        {
            await _table.AddRangeAsync(entities);
            await Context.SaveChangesAsync();
        }
        public virtual void RemoveRange(IEnumerable<T> entities, bool commit = true)
        {
            _table.RemoveRange(entities);
            Context.SaveChanges();
        }
        public virtual async Task RemoveRangeAsync(IEnumerable<T> entities, bool commit = true)
        {
            _table.RemoveRange(entities);
            await Context.SaveChangesAsync();
        }
        public virtual IEnumerable<T> GetAllAsIEnumerable() => this.GetAllAsIQueryable().AsEnumerable();
        public virtual IQueryable<T> GetAllAsIQueryable() => _table.AsQueryable();
        public virtual async Task<IEnumerable<T>> GetAllAsync() => await _table.ToListAsync();
        public  virtual T GetById(long id) => _table.Find(id);
        public virtual T GetById(int id) => _table.Find(id);
        public virtual Task<T> GetByIdAsync(long id) => _table.FindAsync(id).AsTask();
        public DbSet<T> GetDbSet()
        {
            return Context.Set<T>();
        }
        public virtual Task<T> GetByIdAsync(int id) => _table.FindAsync(id).AsTask();
        public virtual void Remove(T entity, bool commit = true)
        {
            _table.Remove(entity);
            Context.SaveChanges();
        }
        public virtual async Task RemoveAsync(T entity, bool commit = true)
        {
            _table.Remove(entity);
            await Context.SaveChangesAsync();
        }
        public virtual void Update(T entity, bool commit = true)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }
        public virtual Task UpdateAsync(T entity, bool commit = true)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return Context.SaveChangesAsync();
        }
        public virtual void UpdateRange(IEnumerable<T> entities, bool commit = true)
        {
            Context.UpdateRange(entities);
            Context.SaveChanges();
        }
        public virtual async Task UpdateRangeAsync(IEnumerable<T> entities, bool commit = true)
        { 
            Context.UpdateRange(entities);
            await Context.SaveChangesAsync();
        }
        public virtual IEnumerable<T> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return GetAllAsIQueryable().Where(predicate).AsEnumerable();

        }
        public void SaveChanges()
        {
            Context.SaveChanges();
        }
        public async Task SaveChangesAsync()
        {
            await Context.SaveChangesAsync();
        }
        public virtual async Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> predicate)
        {
            return await _table.Where(predicate).ToListAsync();
        }
    }
}
