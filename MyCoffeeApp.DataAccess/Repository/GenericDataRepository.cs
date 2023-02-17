using Microsoft.EntityFrameworkCore;
using MyCoffeeApp.DataAccess.Interfaces;

namespace MyCoffeeApp.DataAccess.Repository
{
    public class GenericDataRepository<T> : IGenericDataRepository<T> where T : class
    {
        private IDbContextFactory<DbContext> _contextFactory;
        private DbSet<T> _dbSet;
        public GenericDataRepository(IDbContextFactory<DbContext> context)
        {
            _contextFactory = context;
            _dbSet = _contextFactory.CreateDbContext().Set<T>();
        }
        public async Task<T> CreateAsync(T entity)
        {
            var newEntity = await _dbSet.AddAsync(entity);
            if (newEntity == null)
            {
                return null;
            }
            await _contextFactory.CreateDbContext().SaveChangesAsync();
            return newEntity.Entity;
        }

        public async Task<bool> DeleteAsync(object id)
        {
            var entity = _dbSet.Find(id);
            if (entity == null)
            {
                return false;
            }
            _dbSet.Remove(entity);
            await _contextFactory.CreateDbContext().SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var entities = await _dbSet.ToListAsync();
            if (entities == null)
            {
                return null;
            }
            return entities;
        }

        public async Task<T> GetByIdAsync(object id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
            {
                return null;
            }
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Attach(entity);
            _contextFactory.CreateDbContext().Entry(entity).State = EntityState.Modified;
            await _contextFactory.CreateDbContext().SaveChangesAsync();
            return entity;
        }
    }
}
