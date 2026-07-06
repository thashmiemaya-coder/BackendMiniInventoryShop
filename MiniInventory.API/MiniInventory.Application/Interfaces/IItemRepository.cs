using MiniInventory.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiniInventory.Application.Interfaces
{
    public interface IItemRepository : IGenericRepository<Item>
    {
        Task<IEnumerable<Item>> SearchAsync(string keyword);
        Task<IEnumerable<Item>> GetItemsByCategoryAsync(int categoryId);
        Task<IEnumerable<Item>> GetItemsBySupplierAsync(int supplierId);
        Task<IEnumerable<Item>> GetLowStockItemsAsync();
        Task<Item?> GetItemWithDetailsAsync(int id);
        Task<bool> IsItemCodeExistsAsync(string itemCode);
    }
}