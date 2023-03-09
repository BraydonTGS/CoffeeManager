using Microsoft.AspNetCore.Mvc;
using MyCoffeeApp.Application.Interfaces;
using MyCoffeeApp.Domain.DTO;
using MyCoffeeApp.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyCoffeeApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeController : ControllerBase
    {
        private readonly ICoffeeService _service;
        public CoffeeController(ICoffeeService service)
        {
            _service = service;
        }

        [HttpGet]
        [ActionName("GetAllCoffeesRequest")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _service.GetAllAsync();
                return Ok(result);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }


        [HttpGet("{id:guid}")]
        [ActionName("GetCoffeeByIdRequest")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var result = await _service.GetByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        [HttpPost]
        [ActionName("CreateCoffeeRequest")]
        public async Task<IActionResult> Post([FromBody] CoffeeRequest request)
        {
            try
            {
                var result = await _service.CreateAsync(request);
                return Ok(result);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        [HttpPut]
        [ActionName("UpdateCoffeeRequest")]
        public async Task<IActionResult> Put([FromBody] CoffeeRequest request)
        {
            try
            {
                var result = await _service.UpdateAsync(request);
                return Ok(result);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        [HttpDelete("{id:guid}")]
        [ActionName("DeleteCoffeeRequest")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _service.DeleteAsync(id);
            if (!result)
            {
                return BadRequest(result);
            }
            return Ok(result);

        }
    }
}

