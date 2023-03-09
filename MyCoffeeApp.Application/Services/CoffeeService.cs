using MyCoffeeApp.Application.Interfaces;
using MyCoffeeApp.Domain.Entities;

namespace MyCoffeeApp.Application.Services
{
    public class CoffeeService : ICoffeeService
    {
        private readonly IGenericDataRepository<Coffee> _repository; 
        public CoffeeService(IGenericDataRepository<Coffee> repository)
        {
            _repository = repository;
        }
        public Task<Coffee> CreateAsync(Coffee entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Coffee>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Coffee> GetByIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<Coffee> UpdateAsync(Coffee entity)
        {
            throw new NotImplementedException();
        }
    }
}
