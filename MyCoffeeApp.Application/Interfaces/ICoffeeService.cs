using MyCoffeeApp.Domain.Entities;

namespace MyCoffeeApp.Application.Interfaces
{
    public interface ICoffeeService
    {
        public Task<IEnumerable<Coffee>> GetAllAsync();
        public Task<Coffee> GetByIdAsync(Guid Id);
        public Task <Coffee> CreateAsync(Coffee entity);
        public Task<Coffee> UpdateAsync(Coffee entity);
        public Task<bool> DeleteAsync(Guid id);
    }
}
