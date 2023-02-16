namespace MyCoffeeApp.DataAccess.Interfaces
{
    public interface IGenericDataRepository<T>
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetByIdAsync(Guid Id);
        public Task<T> CreateAsync(T args);
        public Task<T> UpdateAsync(Guid id, T args);
        public Task<bool> DeleteAsync(int id);
    }
}
