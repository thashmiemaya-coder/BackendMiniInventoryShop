using Microsoft.EntityFrameworkCore;
using MiniInventory.Application.Interfaces;
using MiniInventory.Domain.Entities;
using MiniInventory.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniInventory.Infrastructure.Repositories
{
    public class StockOutRepository : GenericRepository<StockOut>, IStockOutRepository
    {
        public StockOutRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<StockOut>> GetStockOutsByItemAsync(int itemId)
        {
            return await _context.StockOuts
                .Include(s => s.Item)
                .Where(s => s.ItemId == itemId)
                .OrderByDescending(s => s.StockOutDate)
                .ToListAsync();
        }

        public async Task<int> GetTotalStockOutByItemAsync(int itemId)
        {
            return await _context.StockOuts
                .Where(s => s.ItemId == itemId)
                .SumAsync(s => s.Quantity);
        }

        public async Task<IEnumerable<StockOut>> GetStockOutsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.StockOuts
                .Include(s => s.Item)
                .Where(s => s.StockOutDate >= startDate && s.StockOutDate <= endDate)
                .OrderByDescending(s => s.StockOutDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<StockOut>> GetStockOutsByReasonAsync(string reason)
        {
            return await _context.StockOuts
                .Include(s => s.Item)
                .Where(s => s.Reason.Contains(reason))
                .OrderByDescending(s => s.StockOutDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<StockOut>> GetAllStockOutsWithDetailsAsync()
        {
            return await _context.StockOuts
                .Include(s => s.Item)
                .OrderByDescending(s => s.StockOutDate)
                .ToListAsync();
        }
    }
}