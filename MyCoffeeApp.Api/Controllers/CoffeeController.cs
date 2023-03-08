using Microsoft.AspNetCore.Mvc;
using MyCoffeeApp.DataAccess.Entities;
using MyCoffeeApp.DataAccess.Interfaces;
using MyCoffeeApp.Domain.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyCoffeeApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeController : ControllerBase
    {
        private readonly IGenericDataRepository<Coffee> _repository;
        public CoffeeController(IGenericDataRepository<Coffee> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ActionName("GetAllCoffeesRequest")]
        public async Task<IActionResult> Get()
        {
            var result = await _repository.GetAllAsync();
            var coffees = new List<CoffeeRequest>();
            foreach (var coffee in result)
            {
                var cafe = new CoffeeRequest()
                {
                    CoffeeName = coffee.CoffeeName,
                    CoffeeRoaster = coffee.CoffeeRoaster,
                    ImagePath = coffee.ImagePath
                };
                coffees.Add(cafe);
            }
            return Ok(coffees);
        }


        [HttpGet("{id:guid}")]
        [ActionName("GetCoffeeByIdRequest")]
        public async Task<IActionResult> Get(Guid id)
        {
            var coffee = await _repository.GetByIdAsync(id);
            if (coffee == null)
            {
                return NotFound();
            }
            var result = new CoffeeDto()
            {
                CoffeeName = coffee.CoffeeName,
                CoffeeRoaster = coffee.CoffeeRoaster,
                ImagePath = coffee.ImagePath
            };
            return Ok(result);
        }
        
        [HttpPost]
        [ActionName("CreateCoffeeRequest")]
        public async Task<IActionResult> Post([FromBody] CoffeeRequest coffeeDto)
        {
            var coffee = new Coffee()
            {
                CoffeeId = new Guid(),
                CoffeeName = coffeeDto.CoffeeName,
                CoffeeRoaster = coffeeDto.CoffeeRoaster,
                ImagePath = coffeeDto.ImagePath
            };

            var createdCoffee = await _repository.CreateAsync(coffee);

            if (createdCoffee == null)
            {
                return BadRequest(createdCoffee);
            }

            var result = new CoffeeDto()
            {
                CoffeeId = createdCoffee.CoffeeId,
                CoffeeName = coffeeDto.CoffeeName,
                CoffeeRoaster = coffeeDto.CoffeeRoaster,
                ImagePath = createdCoffee.ImagePath
            };
            return Ok(result);
        }

        [HttpPut]
        [ActionName("UpdateCoffeeRequest")]
        public async Task<IActionResult> Put([FromBody] CoffeeRequest coffeeDto)
        {
            var coffee = new Coffee()
            {
                CoffeeName = coffeeDto.CoffeeName,
                CoffeeRoaster = coffeeDto.CoffeeRoaster,
                ImagePath = coffeeDto.ImagePath,
            };

            var updatedCoffee = await _repository.UpdateAsync(coffee);

            if (updatedCoffee == null)
            {
                return BadRequest(updatedCoffee); 
            }

            var result = new CoffeeDto()
            {
                CoffeeId = updatedCoffee.CoffeeId,
                CoffeeName = coffeeDto.CoffeeName,
                CoffeeRoaster = coffeeDto.CoffeeRoaster,
                ImagePath = updatedCoffee.ImagePath
            };

           return(Ok(result));
        }

        [HttpDelete("{id:guid}")]
        [ActionName("DeleteCoffeeRequest")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _repository.DeleteAsync(id);
            if (!result)
            {
                return BadRequest(result); 
            }
            return Ok(result);  

        }
    }
}

