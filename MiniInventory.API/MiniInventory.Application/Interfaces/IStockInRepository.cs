using MiniInventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiniInventory.Application.Interfaces
{
    public interface IStockInRepository : IGenericRepository<StockIn>
    {
        Task<IEnumerable<StockIn>> GetStockInsByItemAsync(int itemId);
        Task<int> GetTotalStockInByItemAsync(int itemId);
        Task<IEnumerable<StockIn>> GetStockInsByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<StockIn>> GetAllStockInsWithDetailsAsync();
        //Task<IEnumerable<StockOut>> GetAllStockOutsWithDetailsAsync();
    }
}