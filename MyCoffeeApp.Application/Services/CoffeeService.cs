using MyCoffeeApp.Application.Interfaces;
using MyCoffeeApp.Domain.DTO;
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
        public async Task<CoffeeDto> CreateAsync(CoffeeRequest request)
        {
            var coffee = new Coffee()
            {
                CoffeeId = new Guid(),
                CoffeeName = request.CoffeeName,
                CoffeeRoaster = request.CoffeeRoaster,
                ImagePath = request.ImagePath,
                UserId = new Guid("53D4FA69-970B-4963-A409-51E1F552BAE4")
            };

            var createdCoffee = await _repository.CreateAsync(coffee);

            var result = new CoffeeDto()
            {
                CoffeeId = createdCoffee.CoffeeId,
                CoffeeName = createdCoffee.CoffeeName,
                CoffeeRoaster = createdCoffee.CoffeeRoaster,
                ImagePath = createdCoffee.ImagePath
            };
            return result;

        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CoffeeDto>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();
            var coffees = new List<CoffeeDto>();
            foreach (var coffee in result)
            {
                var cafe = new CoffeeDto()
                {
                    CoffeeId = coffee.CoffeeId,
                    CoffeeName = coffee.CoffeeName,
                    CoffeeRoaster = coffee.CoffeeRoaster,
                    ImagePath = coffee.ImagePath
                };
                coffees.Add(cafe);
            }
            return coffees;
        }

        public async Task<CoffeeDto> GetByIdAsync(Guid Id)
        {
            var coffee = await _repository.GetByIdAsync(Id);
            var result = new CoffeeDto()
            {
                CoffeeId = coffee.CoffeeId,
                CoffeeName = coffee.CoffeeName,
                CoffeeRoaster = coffee.CoffeeRoaster,
                ImagePath = coffee.ImagePath
            };
            return result;
        }

        public async Task<CoffeeDto> UpdateAsync(CoffeeRequest request)
        {
            var coffee = new Coffee()
            {
                CoffeeId = request.CoffeeId,
                CoffeeName = request.CoffeeName,
                CoffeeRoaster = request.CoffeeRoaster,
                ImagePath = request.ImagePath,
                UserId = new Guid("53D4FA69-970B-4963-A409-51E1F552BAE4")
            };

            var updatedCoffee = await _repository.UpdateAsync(coffee);

            var result = new CoffeeDto()
            {
                CoffeeId = updatedCoffee.CoffeeId,
                CoffeeName = updatedCoffee.CoffeeName,
                CoffeeRoaster = updatedCoffee.CoffeeRoaster,
                ImagePath = updatedCoffee.ImagePath
            };

            return result;
        }
    }
}
