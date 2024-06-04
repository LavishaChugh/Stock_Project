using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Services.Sale;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISaleService _saleService;

        public SalesController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Sales>>> GetAll()
        {
            var result = await _saleService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sales>> GetById(Guid id)
        {
            var result = await _saleService.GetItemById(id);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<List<Sales>>> Delete(Guid id)
        {
            var result = await _saleService.DeleteItem(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Sales>>> Add(List<Sales> sales)
        {
            var result = await _saleService.AddItem(sales);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<List<Sales>>> Update(Sales sales)
        {
            var result = await _saleService.UpdateItem(sales);
            return Ok(result);
        }
    }
}
