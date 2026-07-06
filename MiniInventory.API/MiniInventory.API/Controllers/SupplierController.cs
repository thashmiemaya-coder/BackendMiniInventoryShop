using Microsoft.AspNetCore.Mvc;
using MiniInventory.Application.Interfaces;
using MiniInventory.Shared.CommonResponse;
using System.Threading.Tasks;
using MiniInventory.Application.DTOs;

namespace MiniInventory.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _supplierService.GetAllSuppliersAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _supplierService.GetSupplierByIdAsync(id);
            if (!result.Success)
                return NotFound(result);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SupplierCreateDto supplierDto)
        {
            var result = await _supplierService.CreateSupplierAsync(supplierDto);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SupplierUpdateDto supplierDto)
        {
            if (id != supplierDto.SupplierId)
                return BadRequest(ApiResponse<SupplierDto>.ErrorResponse("ID mismatch"));

            var result = await _supplierService.UpdateSupplierAsync(supplierDto);
            if (!result.Success)
                return NotFound(result);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _supplierService.DeleteSupplierAsync(id);
            if (!result.Success)
                return NotFound(result);
            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string keyword)
        {
            var result = await _supplierService.SearchSuppliersAsync(keyword);
            return Ok(result);
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetActive()
        {
            var result = await _supplierService.GetActiveSuppliersAsync();
            return Ok(result);
        }
    }
}