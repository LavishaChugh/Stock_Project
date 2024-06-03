using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Services.Purchases;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;

        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }


        //GetAll Items
        [HttpGet("GetAll/Items")]
        public async Task<ActionResult<List<Purchase>>> GetAll()
        {
            var items = await _purchaseService.GetAll();
            return Ok(items);
        }


        //Get-Item by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Purchase>> GetById(Guid id)
        {

            var item = await _purchaseService.GetById(id);
            return Ok(item);
        }

        //Delete-Item
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Purchase>>> Delete(Guid id)
        {
            var items = await _purchaseService.Delete(id);
            return Ok(items);
        }

        //Post-Item
        [HttpPost]
        public async Task<ActionResult<List<Purchase>>> AddItem(Purchase item)
        {
            var items = await _purchaseService.Add(item);
            return Ok(items);
        }

        //Update-Item
        [HttpPut]
        public async Task<ActionResult<List<Purchase>>> UpdateItem(Purchase item)
        {
            var items = await _purchaseService.Update(item);
            return Ok(items);
        }
    }
}
