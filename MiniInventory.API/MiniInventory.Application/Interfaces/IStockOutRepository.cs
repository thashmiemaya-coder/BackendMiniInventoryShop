using MiniInventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiniInventory.Application.Interfaces
{
    public interface IStockOutRepository : IGenericRepository<StockOut>
    {
        Task<IEnumerable<StockOut>> GetStockOutsByItemAsync(int itemId);
        Task<int> GetTotalStockOutByItemAsync(int itemId);
        Task<IEnumerable<StockOut>> GetStockOutsByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<StockOut>> GetStockOutsByReasonAsync(string reason);
        Task<IEnumerable<StockOut>> GetAllStockOutsWithDetailsAsync();
    }
}