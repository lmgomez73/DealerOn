using DealerOn.Models.DTO;
using DealerOn.Models.Interfaces;
using DealerOn.Repository;
using DealerOn.Repository.Interfaces;
using DealerOn.Utils;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DealerOn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISalesRepository _repository;
        private readonly SaleHelper _saleHelper;
        public SalesController(ISalesRepository repository, SaleHelper saleHelper)
        {
            _repository = repository;
            _saleHelper = saleHelper;
        }
        // GET: api/<SalesController>
        [HttpGet]
        public IActionResult Get()
        {
            var sales = _repository.GetAll();
            var result = sales.Select(x=> _saleHelper.SaleToString(x)).ToList();
            return Ok(result);
        }

        // GET api/<SalesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _repository.GetById(id);
            if (result == null)
            {
                return BadRequest($"Sale {id} not found");
            }
            return Ok(result);
        }

        // POST api/<SalesController>
        [HttpPost]
        public IActionResult Post([FromBody] SaleDTO value)
        {
            try
            {

                ISale sale = _saleHelper.CreateSale(value);
                _repository.Add(sale);
                return Ok(_saleHelper.SaleToString(sale));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


    }
}
