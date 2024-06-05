global using Microsoft.AspNetCore.Mvc;
global using Project.Services.Item;
using Microsoft.AspNetCore.Authorization;

namespace Project.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemsService _itemService;

        public ItemController(IItemsService itemService)
        {
            _itemService = itemService;
        }


        //GetAll Items
        [HttpGet("GetAll/Items")]
        public async Task<ActionResult<List<Items>>> GetAllItems()
        {
            var items = await _itemService.GetAll();
            return Ok(items);
        }


        //Get-Item by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Items>> GetItemById(Guid id)
        {

            var item = await _itemService.GetItemById(id);
            return Ok(item);
        }

        //Delete-Item
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Items>>> DeleteItem(Guid id)
        {
            var items = await _itemService.DeleteItem(id);
            return Ok(items);
        }

        //Post-Item
        [HttpPost]
        public async Task<ActionResult<List<Items>>> AddItem(List<Items> item)
        {
            var items = await _itemService.AddItem(item);
            return Ok(items);
        }

        //Update-Item
        [HttpPut]
        public async Task<ActionResult<List<Items>>> UpdateItem(Items item)
        {
            var items = await _itemService.UpdateItem(item);
            return Ok(items);
        }
    }
}
