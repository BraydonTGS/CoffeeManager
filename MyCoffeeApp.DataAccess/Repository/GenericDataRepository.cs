using Microsoft.EntityFrameworkCore;
using MyCoffeeApp.DataAccess.Context;
using MyCoffeeApp.DataAccess.Interfaces;

namespace MyCoffeeApp.DataAccess.Repository
{
    public class GenericDataRepository<T> : IGenericDataRepository<T> where T : class
    {
        private IDbContextFactory<CoffeeDbContext> _contextFactory;

        public GenericDataRepository(IDbContextFactory<CoffeeDbContext> context)
        {
            _contextFactory = context;
        }

        public async Task<T> CreateAsync(T entity)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var newEntity = await context.Set<T>().AddAsync(entity);
                if (newEntity == null)
                {
                    return null;
                }
                await context.SaveChangesAsync();
                return newEntity.Entity;
            }
        }

        public async Task<bool> DeleteAsync(object id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var entity = context.Set<T>().Find(id);
                if (entity == null)
                {
                    return false;
                }
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var entities = await context.Set<T>().ToListAsync();
                if (entities == null)
                {
                    return null;
                }
                return entities;
            }

        }

        public async Task<T> GetByIdAsync(object id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var entity = await context.Set<T>().FindAsync(id);
                if (entity == null)
                {
                    return null;
                }
                return entity;
            }
        }

        public async Task<T> UpdateAsync(T entity)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.Set<T>().Attach(entity);
                context.Entry(entity).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return entity;
            }

        }
    }
}
