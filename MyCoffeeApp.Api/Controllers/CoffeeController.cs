using Microsoft.AspNetCore.Mvc;
using MyCoffeeApp.DataAccess.Context;
using MyCoffeeApp.DataAccess.Entities;
using MyCoffeeApp.DataAccess.Interfaces;

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
        // GET: api/<CoffeeController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
           var test = await _repository.GetAllAsync();
            return Ok(test);
        }

        // GET api/<CoffeeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CoffeeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CoffeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CoffeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
