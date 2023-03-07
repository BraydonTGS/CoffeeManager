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
            var coffees = new List<CoffeeDto>();
            foreach (var coffee in result)
            {
                var cafe = new CoffeeDto()
                {
                    CoffeeId = coffee.CoffeeId,
                    CoffeeName = coffee.CoffeeName,
                    CoffeeRoaster = coffee.CoffeeRoaster,
                    ImagePath = coffee.ImagePath,
                    UserId = coffee.UserId,
                };
                coffees.Add(cafe);
            }
            return Ok(coffees);
        }


        [HttpGet("{id:guid}")]
        [ActionName("GetCoffeeByIdRequest")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _repository.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            var coffee = new CoffeeDto()
            {
                CoffeeId = result.CoffeeId,
                CoffeeName = result.CoffeeName,
                CoffeeRoaster = result.CoffeeRoaster,
                ImagePath = result.ImagePath,
                UserId = result.UserId,
            };
            return Ok(coffee);
        }

        [HttpPost]
        [ActionName("CreateCoffeeRequest")]
        public async Task<IActionResult> Post([FromBody] CoffeeDto coffeeDto)
        {
            var coffee = new Coffee()
            {
                CoffeeName = coffeeDto.CoffeeName,
                CoffeeRoaster = coffeeDto.CoffeeRoaster,
                ImagePath = coffeeDto.ImagePath,
                UserId = coffeeDto.UserId,
            };
            var result = await _repository.CreateAsync(coffee);
            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut]
        [ActionName("UpdateCoffeeRequest")]
        public async Task<IActionResult> Put([FromBody] CoffeeDto coffeeDto)
        {
            var coffee = new Coffee()
            {
                CoffeeName = coffeeDto.CoffeeName,
                CoffeeRoaster = coffeeDto.CoffeeRoaster,
                ImagePath = coffeeDto.ImagePath,
                UserId = coffeeDto.UserId,
            };
            var restult = await _repository.UpdateAsync(coffee);
            if (restult == null)
            {
                return BadRequest(); 
            }
           return(Ok(restult));
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

