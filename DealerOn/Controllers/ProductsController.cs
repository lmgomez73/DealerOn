using DealerOn.Models.DTO;
using DealerOn.Models.Interfaces;
using DealerOn.Repository.Interfaces;
using DealerOn.Utils;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DealerOn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly ProductFactory _factory;

        public ProductsController(IProductRepository repository, ProductFactory factory)
        {
            this._repository = repository;
            this._factory = factory;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = _repository.GetAll().Select(x =>
            new{
                x.Id,
                x.Name,
                x.ListPrice
            });
            return Ok(result);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _repository.GetById(id);
            if (result == null)
            {
                return BadRequest($"Product {id} not found");
            }
            return Ok(result);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public IActionResult Post([FromBody] ProductDTO value)
        {
            var product = _factory.CreateProduct(value);
            return Ok(_repository.Add(product));
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProductDTO value)
        {

            var product = _factory.CreateProduct(value);

            try
            {
                _repository.Update(product);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _repository.GetById(id);
            _repository.Delete(product);
            return Ok();
        }
    }
}
