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
            await _contextFactory.CreateDbContext().SaveChangesAsync();
            return newEntity.Entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
            await _contextFactory.CreateDbContext().SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);
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
