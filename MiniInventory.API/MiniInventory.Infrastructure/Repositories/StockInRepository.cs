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
    public class StockInRepository : GenericRepository<StockIn>, IStockInRepository
    {
        public StockInRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<StockIn>> GetStockInsByItemAsync(int itemId)
        {
            return await _context.StockIns
                .Include(s => s.Item)
                .Include(s => s.Supplier)
                .Where(s => s.ItemId == itemId)
                .OrderByDescending(s => s.StockInDate)
                .ToListAsync();
        }

        public async Task<int> GetTotalStockInByItemAsync(int itemId)
        {
            return await _context.StockIns
                .Where(s => s.ItemId == itemId)
                .SumAsync(s => s.Quantity);
        }

        public async Task<IEnumerable<StockIn>> GetStockInsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.StockIns
                .Include(s => s.Item)
                .Include(s => s.Supplier)
                .Where(s => s.StockInDate >= startDate && s.StockInDate <= endDate)
                .OrderByDescending(s => s.StockInDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<StockIn>> GetAllStockInsWithDetailsAsync()
        {
            return await _context.StockIns
                .Include(s => s.Item)
                .Include(s => s.Supplier)
                .OrderByDescending(s => s.StockInDate)
                .ToListAsync();
        }
    }
}