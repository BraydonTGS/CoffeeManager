namespace MyCoffeeApp.DataAccess.Interfaces
{
    public interface IGenericDataRepository<T>
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetByIdAsync(object Id);
        public Task<T> CreateAsync(T entity);
        public Task<T> UpdateAsync(T entity);
        public Task<bool> DeleteAsync(object id);
    }
}
