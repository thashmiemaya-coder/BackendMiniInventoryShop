using Microsoft.AspNetCore.Mvc;
using MiniInventory.Application.Interfaces;
using MiniInventory.Shared.CommonResponse;
using System.Threading.Tasks;
using MiniInventory.Application.DTOs;

namespace MiniInventory.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _categoryService.GetAllCategoriesAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _categoryService.GetCategoryByIdAsync(id);
            if (!result.Success)
                return NotFound(result);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryCreateDto categoryDto)
        {
            var result = await _categoryService.CreateCategoryAsync(categoryDto);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CategoryUpdateDto categoryDto)
        {
            if (id != categoryDto.CategoryId)
                return BadRequest(ApiResponse<CategoryDto>.ErrorResponse("ID mismatch"));

            var result = await _categoryService.UpdateCategoryAsync(categoryDto);
            if (!result.Success)
                return NotFound(result);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoryService.DeleteCategoryAsync(id);
            if (!result.Success)
                return NotFound(result);
            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string keyword)
        {
            var result = await _categoryService.SearchCategoriesAsync(keyword);
            return Ok(result);
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetActive()
        {
            var result = await _categoryService.GetActiveCategoriesAsync();
            return Ok(result);
        }
    }
}