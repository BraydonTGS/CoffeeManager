namespace MyCoffeeApp.DataAccess.Interfaces
{
    public interface IGenericDataRepository<T>
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetByIdAsync(Guid Id);
        public Task<T> CreateAsync(T entity);
        public Task<T> UpdateAsync(T entity);
        public Task<bool> DeleteAsync(Guid id);
    }
}
