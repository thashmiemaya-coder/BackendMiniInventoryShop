using Microsoft.EntityFrameworkCore;
using MiniInventory.Application.Interfaces;
using MiniInventory.Domain.Entities;
using MiniInventory.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniInventory.Infrastructure.Repositories
{
    public class ItemRepository : GenericRepository<Item>, IItemRepository
    {
        public ItemRepository(AppDbContext context) : base(context)
        {
        }

        // ===== UPDATED: Include Category and Supplier =====
        public override async Task<IEnumerable<Item>> GetAllAsync()
        {
            return await _context.Items
                .Include(i => i.Category)    // ← ADDED
                .Include(i => i.Supplier)    // ← ADDED
                .ToListAsync();
        }

        public async Task<IEnumerable<Item>> SearchAsync(string keyword)
        {
            return await _context.Items
                .Include(i => i.Category)
                .Include(i => i.Supplier)
                .Where(i => i.ItemName.Contains(keyword) ||
                           (i.Barcode != null && i.Barcode.Contains(keyword)) ||
                           i.ItemCode.Contains(keyword))
                .ToListAsync();
        }

        public async Task<IEnumerable<Item>> GetItemsByCategoryAsync(int categoryId)
        {
            return await _context.Items
                .Include(i => i.Category)
                .Include(i => i.Supplier)
                .Where(i => i.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Item>> GetItemsBySupplierAsync(int supplierId)
        {
            return await _context.Items
                .Include(i => i.Category)
                .Include(i => i.Supplier)
                .Where(i => i.SupplierId == supplierId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Item>> GetLowStockItemsAsync()
        {
            return await _context.Items
                .Include(i => i.Category)
                .Include(i => i.Supplier)
                .Where(i => i.IsActive)
                .ToListAsync();
        }

        public async Task<Item?> GetItemWithDetailsAsync(int id)
        {
            return await _context.Items
                .Include(i => i.Category)
                .Include(i => i.Supplier)
                .Include(i => i.StockIns)
                .Include(i => i.StockOuts)
                .FirstOrDefaultAsync(i => i.ItemId == id);
        }

        public async Task<bool> IsItemCodeExistsAsync(string itemCode)
        {
            return await _context.Items
                .AnyAsync(i => i.ItemCode == itemCode);
        }
    }
}