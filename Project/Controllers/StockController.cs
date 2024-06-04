using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Services.stock;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;

        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Stocks>>> GetAll()
        {
            var result = await _stockService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Stocks>> GetStockById(Guid id)
        {
            var result = await _stockService.GetStockById(id);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<List<Stocks>>> Delete(Guid id)
        {
            var result = await _stockService.DeleteStock(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Stocks>>> AddStock(List<Stocks> stocks)
        {
            var result = await _stockService.AddStock(stocks);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<List<Stocks>>> UpdateStock(Stocks stocks)
        {
            var result = await _stockService.UpdateStock(stocks);
            return Ok(result);
        }

    }
}
