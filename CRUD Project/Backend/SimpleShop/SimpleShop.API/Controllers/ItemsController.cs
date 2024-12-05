using Microsoft.AspNetCore.Mvc;
using SimpleShop.API.Contracts;
using SimpleShop.Application.Services;
using SimpleShop.Core.models;
using System.Net.WebSockets;

namespace SimpleShop.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemService _itemService;
        public ItemsController(IItemService itemsService) 
        {
            _itemService = itemsService;
        }
        [HttpGet]
        public async Task<ActionResult<List<ItemsResponse>>> GetItems()
        {
            var items = await _itemService.GetAllItems();

            var response = items.Select(i => new ItemsResponse(i.Id, i.Title, i.Description, i.Price));

            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> CreateItem([FromBody] ItemsRequest request)
        {
            var (item, error) = Item.Create(
                Guid.NewGuid(),
                request.Title,
                request.Description,
                request.Price);
            if(!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var itemId = await _itemService.CreateItem(item);

            return Ok(itemId);
        }
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateItems(Guid id, [FromBody] ItemsRequest request)
        {
            var itemId = await _itemService.UpdateItem(id, request.Title, request.Description, request.Price);
            return Ok(itemId);
        }
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteItems(Guid id)
        {
            var itemId = await _itemService.DeleteItem(id);

            return Ok(itemId);
        }
    }
}
