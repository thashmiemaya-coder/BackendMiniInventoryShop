using MiniInventory.Application.DTOs;
using MiniInventory.Shared.CommonResponse;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiniInventory.Application.Interfaces
{
    public interface IItemService
    {
        Task<ApiResponse<IEnumerable<ItemDto>>> GetAllItemsAsync();
        Task<ApiResponse<ItemDto>> GetItemByIdAsync(int id);
        Task<ApiResponse<ItemDto>> CreateItemAsync(ItemCreateDto itemDto);
        Task<ApiResponse<ItemDto>> UpdateItemAsync(ItemUpdateDto itemDto);
        Task<ApiResponse<bool>> DeleteItemAsync(int id);
        Task<ApiResponse<IEnumerable<ItemDto>>> SearchItemsAsync(string keyword);
        Task<ApiResponse<IEnumerable<ItemDto>>> GetItemsByCategoryAsync(int categoryId);
        Task<ApiResponse<IEnumerable<ItemDto>>> GetItemsBySupplierAsync(int supplierId);
        Task<ApiResponse<IEnumerable<ItemDto>>> GetLowStockItemsAsync();
        Task<ApiResponse<ItemDto>> GetItemWithDetailsAsync(int id);
    }
}