using Microsoft.AspNetCore.Mvc;
using MiniInventory.Application.Interfaces;
using MiniInventory.Shared.CommonResponse;
using System.Threading.Tasks;
using MiniInventory.Application.DTOs;

namespace MiniInventory.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;

        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }

        // ===== STOCK IN =====
        [HttpPost("in")]
        public async Task<IActionResult> AddStockIn([FromBody] StockInCreateDto stockInDto)
        {
            var result = await _stockService.AddStockInAsync(stockInDto);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("in/item/{itemId}")]
        public async Task<IActionResult> GetStockInsByItem(int itemId)
        {
            var result = await _stockService.GetStockInsByItemAsync(itemId);
            return Ok(result);
        }

        [HttpGet("records")]
        public async Task<IActionResult> GetAllStockIns()
        {
            var result = await _stockService.GetAllStockInsAsync();
            return Ok(result);
        }

        // ===== STOCK OUT =====
        [HttpPost("out")]
        public async Task<IActionResult> AddStockOut([FromBody] StockOutCreateDto stockOutDto)
        {
            var result = await _stockService.AddStockOutAsync(stockOutDto);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("out/item/{itemId}")]
        public async Task<IActionResult> GetStockOutsByItem(int itemId)
        {
            var result = await _stockService.GetStockOutsByItemAsync(itemId);
            return Ok(result);
        }

        // ===== STOCK BALANCE =====
        [HttpGet("balance")]
        public async Task<IActionResult> GetStockBalance()
        {
            var result = await _stockService.GetStockBalanceAsync();
            return Ok(result);
        }

        [HttpGet("low-stock")]
        public async Task<IActionResult> GetLowStockReport()
        {
            var result = await _stockService.GetLowStockItemsReportAsync();
            return Ok(result);
        }

        [HttpGet("out/records")]
        public async Task<IActionResult> GetAllStockOuts()
        {
            var result = await _stockService.GetAllStockOutsAsync();
            return Ok(result);
        }
    }
}