using MiniInventory.Application.DTOs;
using MiniInventory.Shared.CommonResponse;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiniInventory.Application.Interfaces
{
    public interface IStockService
    {
        // Stock In
        Task<ApiResponse<StockInDto>> AddStockInAsync(StockInCreateDto stockInDto);
        Task<ApiResponse<IEnumerable<StockInDto>>> GetStockInsByItemAsync(int itemId);
        Task<ApiResponse<IEnumerable<StockInDto>>> GetAllStockInsAsync();

        // Stock Out
        Task<ApiResponse<StockOutDto>> AddStockOutAsync(StockOutCreateDto stockOutDto);
        Task<ApiResponse<IEnumerable<StockOutDto>>> GetStockOutsByItemAsync(int itemId);

        // Stock Balance
        Task<ApiResponse<IEnumerable<StockBalanceDto>>> GetStockBalanceAsync();
        Task<ApiResponse<IEnumerable<StockBalanceDto>>> GetLowStockItemsReportAsync();
        Task<ApiResponse<IEnumerable<StockOutDto>>> GetAllStockOutsAsync();
    }
}