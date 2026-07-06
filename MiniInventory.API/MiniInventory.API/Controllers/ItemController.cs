using Microsoft.AspNetCore.Mvc;
using MiniInventory.Application.Interfaces;
using MiniInventory.Shared.CommonResponse;
using System.Threading.Tasks;
using MiniInventory.Application.DTOs;

namespace MiniInventory.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _itemService.GetAllItemsAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _itemService.GetItemByIdAsync(id);
            if (!result.Success)
                return NotFound(result);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ItemCreateDto itemDto)
        {
            var result = await _itemService.CreateItemAsync(itemDto);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ItemUpdateDto itemDto)
        {
            if (id != itemDto.ItemId)
                return BadRequest(ApiResponse<ItemDto>.ErrorResponse("ID mismatch"));

            var result = await _itemService.UpdateItemAsync(itemDto);
            if (!result.Success)
                return NotFound(result);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _itemService.DeleteItemAsync(id);
            if (!result.Success)
                return NotFound(result);
            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string keyword)
        {
            var result = await _itemService.SearchItemsAsync(keyword);
            return Ok(result);
        }

        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetByCategory(int categoryId)
        {
            var result = await _itemService.GetItemsByCategoryAsync(categoryId);
            return Ok(result);
        }

        [HttpGet("supplier/{supplierId}")]
        public async Task<IActionResult> GetBySupplier(int supplierId)
        {
            var result = await _itemService.GetItemsBySupplierAsync(supplierId);
            return Ok(result);
        }

        [HttpGet("low-stock")]
        public async Task<IActionResult> GetLowStock()
        {
            var result = await _itemService.GetLowStockItemsAsync();
            return Ok(result);
        }

        [HttpGet("{id}/details")]
        public async Task<IActionResult> GetWithDetails(int id)
        {
            var result = await _itemService.GetItemWithDetailsAsync(id);
            if (!result.Success)
                return NotFound(result);
            return Ok(result);
        }
    }
}