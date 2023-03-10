using MyCoffeeApp.Domain.DTO;
using MyCoffeeApp.Domain.Entities;

namespace MyCoffeeApp.Application.Interfaces
{
    public interface ICoffeeService
    {
        public Task<IEnumerable<CoffeeDto>> GetAllAsync();
        public Task<CoffeeDto> GetByIdAsync(Guid Id);
        public Task <CoffeeDto> CreateAsync(CoffeeRequest entity);
        public Task<CoffeeDto> UpdateAsync(CoffeeRequest entity);
        public Task<bool> DeleteAsync(Guid id);
    }
}
