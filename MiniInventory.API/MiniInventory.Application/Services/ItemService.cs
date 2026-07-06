using MiniInventory.Application.DTOs;
using MiniInventory.Application.Interfaces;
using MiniInventory.Domain.Entities;
using MiniInventory.Shared.CommonResponse;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniInventory.Application.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IStockInRepository _stockInRepository;
        private readonly IStockOutRepository _stockOutRepository;

        public ItemService(IItemRepository itemRepository, IStockInRepository stockInRepository, IStockOutRepository stockOutRepository)
        {
            _itemRepository = itemRepository;
            _stockInRepository = stockInRepository;
            _stockOutRepository = stockOutRepository;
        }

        public async Task<ApiResponse<IEnumerable<ItemDto>>> GetAllItemsAsync()
        {
            var items = await _itemRepository.GetAllAsync();
            var itemDtos = new List<ItemDto>();

            foreach (var item in items)
            {
                var totalIn = await _stockInRepository.GetTotalStockInByItemAsync(item.ItemId);
                var totalOut = await _stockOutRepository.GetTotalStockOutByItemAsync(item.ItemId);

                itemDtos.Add(new ItemDto
                {
                    ItemId = item.ItemId,
                    ItemCode = item.ItemCode,
                    Barcode = item.Barcode,
                    ItemName = item.ItemName,
                    CategoryId = item.CategoryId,
                    SupplierId = item.SupplierId,
                    CostPrice = item.CostPrice,
                    SellingPrice = item.SellingPrice,
                    ReorderLevel = item.ReorderLevel,
                    IsActive = item.IsActive,
                    CreatedDate = item.CreatedDate,
                    CurrentStock = totalIn - totalOut
                });
            }

            return ApiResponse<IEnumerable<ItemDto>>.SuccessResponse(itemDtos);
        }

        public async Task<ApiResponse<ItemDto>> GetItemByIdAsync(int id)
        {
            var item = await _itemRepository.GetItemWithDetailsAsync(id);
            if (item == null)
                return ApiResponse<ItemDto>.ErrorResponse("Item not found");

            var totalIn = await _stockInRepository.GetTotalStockInByItemAsync(item.ItemId);
            var totalOut = await _stockOutRepository.GetTotalStockOutByItemAsync(item.ItemId);

            var itemDto = new ItemDto
            {
                ItemId = item.ItemId,
                ItemCode = item.ItemCode,
                Barcode = item.Barcode,
                ItemName = item.ItemName,
                CategoryId = item.CategoryId,
                CategoryName = item.Category?.CategoryName,
                SupplierId = item.SupplierId,
                SupplierName = item.Supplier?.SupplierName,
                CostPrice = item.CostPrice,
                SellingPrice = item.SellingPrice,
                ReorderLevel = item.ReorderLevel,
                IsActive = item.IsActive,
                CreatedDate = item.CreatedDate,
                CurrentStock = totalIn - totalOut
            };
            return ApiResponse<ItemDto>.SuccessResponse(itemDto);
        }

        public async Task<ApiResponse<ItemDto>> CreateItemAsync(ItemCreateDto itemDto)
        {
            // Check if ItemCode already exists
            if (await _itemRepository.IsItemCodeExistsAsync(itemDto.ItemCode))
                return ApiResponse<ItemDto>.ErrorResponse("Item code already exists");

            var item = new Item
            {
                ItemCode = itemDto.ItemCode,
                Barcode = itemDto.Barcode,
                ItemName = itemDto.ItemName,
                CategoryId = itemDto.CategoryId,
                SupplierId = itemDto.SupplierId,
                CostPrice = itemDto.CostPrice,
                SellingPrice = itemDto.SellingPrice,
                ReorderLevel = itemDto.ReorderLevel,
                IsActive = itemDto.IsActive
            };

            var created = await _itemRepository.AddAsync(item);

            var result = new ItemDto
            {
                ItemId = created.ItemId,
                ItemCode = created.ItemCode,
                Barcode = created.Barcode,
                ItemName = created.ItemName,
                CategoryId = created.CategoryId,
                SupplierId = created.SupplierId,
                CostPrice = created.CostPrice,
                SellingPrice = created.SellingPrice,
                ReorderLevel = created.ReorderLevel,
                IsActive = created.IsActive,
                CreatedDate = created.CreatedDate,
                CurrentStock = 0
            };
            return ApiResponse<ItemDto>.SuccessResponse(result, "Item created successfully");
        }

        public async Task<ApiResponse<ItemDto>> UpdateItemAsync(ItemUpdateDto itemDto)
        {
            var item = await _itemRepository.GetByIdAsync(itemDto.ItemId);
            if (item == null)
                return ApiResponse<ItemDto>.ErrorResponse("Item not found");

            item.ItemCode = itemDto.ItemCode;
            item.Barcode = itemDto.Barcode;
            item.ItemName = itemDto.ItemName;
            item.CategoryId = itemDto.CategoryId;
            item.SupplierId = itemDto.SupplierId;
            item.CostPrice = itemDto.CostPrice;
            item.SellingPrice = itemDto.SellingPrice;
            item.ReorderLevel = itemDto.ReorderLevel;
            item.IsActive = itemDto.IsActive;

            await _itemRepository.UpdateAsync(item);

            var totalIn = await _stockInRepository.GetTotalStockInByItemAsync(item.ItemId);
            var totalOut = await _stockOutRepository.GetTotalStockOutByItemAsync(item.ItemId);

            var result = new ItemDto
            {
                ItemId = item.ItemId,
                ItemCode = item.ItemCode,
                Barcode = item.Barcode,
                ItemName = item.ItemName,
                CategoryId = item.CategoryId,
                SupplierId = item.SupplierId,
                CostPrice = item.CostPrice,
                SellingPrice = item.SellingPrice,
                ReorderLevel = item.ReorderLevel,
                IsActive = item.IsActive,
                CreatedDate = item.CreatedDate,
                CurrentStock = totalIn - totalOut
            };
            return ApiResponse<ItemDto>.SuccessResponse(result, "Item updated successfully");
        }

        public async Task<ApiResponse<bool>> DeleteItemAsync(int id)
        {
            var item = await _itemRepository.GetByIdAsync(id);
            if (item == null)
                return ApiResponse<bool>.ErrorResponse("Item not found");

            await _itemRepository.DeleteAsync(id);
            return ApiResponse<bool>.SuccessResponse(true, "Item deleted successfully");
        }

        public async Task<ApiResponse<IEnumerable<ItemDto>>> SearchItemsAsync(string keyword)
        {
            var items = await _itemRepository.SearchAsync(keyword);
            var itemDtos = new List<ItemDto>();

            foreach (var item in items)
            {
                var totalIn = await _stockInRepository.GetTotalStockInByItemAsync(item.ItemId);
                var totalOut = await _stockOutRepository.GetTotalStockOutByItemAsync(item.ItemId);

                itemDtos.Add(new ItemDto
                {
                    ItemId = item.ItemId,
                    ItemCode = item.ItemCode,
                    Barcode = item.Barcode,
                    ItemName = item.ItemName,
                    CategoryId = item.CategoryId,
                    CategoryName = item.Category?.CategoryName,
                    SupplierId = item.SupplierId,
                    SupplierName = item.Supplier?.SupplierName,
                    CostPrice = item.CostPrice,
                    SellingPrice = item.SellingPrice,
                    ReorderLevel = item.ReorderLevel,
                    IsActive = item.IsActive,
                    CreatedDate = item.CreatedDate,
                    CurrentStock = totalIn - totalOut
                });
            }

            return ApiResponse<IEnumerable<ItemDto>>.SuccessResponse(itemDtos);
        }

        public async Task<ApiResponse<IEnumerable<ItemDto>>> GetItemsByCategoryAsync(int categoryId)
        {
            var items = await _itemRepository.GetItemsByCategoryAsync(categoryId);
            var itemDtos = new List<ItemDto>();

            foreach (var item in items)
            {
                var totalIn = await _stockInRepository.GetTotalStockInByItemAsync(item.ItemId);
                var totalOut = await _stockOutRepository.GetTotalStockOutByItemAsync(item.ItemId);

                itemDtos.Add(new ItemDto
                {
                    ItemId = item.ItemId,
                    ItemCode = item.ItemCode,
                    Barcode = item.Barcode,
                    ItemName = item.ItemName,
                    CategoryId = item.CategoryId,
                    CategoryName = item.Category?.CategoryName,
                    SupplierId = item.SupplierId,
                    SupplierName = item.Supplier?.SupplierName,
                    CostPrice = item.CostPrice,
                    SellingPrice = item.SellingPrice,
                    ReorderLevel = item.ReorderLevel,
                    IsActive = item.IsActive,
                    CreatedDate = item.CreatedDate,
                    CurrentStock = totalIn - totalOut
                });
            }

            return ApiResponse<IEnumerable<ItemDto>>.SuccessResponse(itemDtos);
        }

        public async Task<ApiResponse<IEnumerable<ItemDto>>> GetItemsBySupplierAsync(int supplierId)
        {
            var items = await _itemRepository.GetItemsBySupplierAsync(supplierId);
            var itemDtos = new List<ItemDto>();

            foreach (var item in items)
            {
                var totalIn = await _stockInRepository.GetTotalStockInByItemAsync(item.ItemId);
                var totalOut = await _stockOutRepository.GetTotalStockOutByItemAsync(item.ItemId);

                itemDtos.Add(new ItemDto
                {
                    ItemId = item.ItemId,
                    ItemCode = item.ItemCode,
                    Barcode = item.Barcode,
                    ItemName = item.ItemName,
                    CategoryId = item.CategoryId,
                    CategoryName = item.Category?.CategoryName,
                    SupplierId = item.SupplierId,
                    SupplierName = item.Supplier?.SupplierName,
                    CostPrice = item.CostPrice,
                    SellingPrice = item.SellingPrice,
                    ReorderLevel = item.ReorderLevel,
                    IsActive = item.IsActive,
                    CreatedDate = item.CreatedDate,
                    CurrentStock = totalIn - totalOut
                });
            }

            return ApiResponse<IEnumerable<ItemDto>>.SuccessResponse(itemDtos);
        }

        public async Task<ApiResponse<IEnumerable<ItemDto>>> GetLowStockItemsAsync()
        {
            var items = await _itemRepository.GetLowStockItemsAsync();
            var itemDtos = new List<ItemDto>();

            foreach (var item in items)
            {
                var totalIn = await _stockInRepository.GetTotalStockInByItemAsync(item.ItemId);
                var totalOut = await _stockOutRepository.GetTotalStockOutByItemAsync(item.ItemId);
                var currentStock = totalIn - totalOut;

                if (currentStock <= item.ReorderLevel)
                {
                    itemDtos.Add(new ItemDto
                    {
                        ItemId = item.ItemId,
                        ItemCode = item.ItemCode,
                        Barcode = item.Barcode,
                        ItemName = item.ItemName,
                        CategoryId = item.CategoryId,
                        CategoryName = item.Category?.CategoryName,
                        SupplierId = item.SupplierId,
                        SupplierName = item.Supplier?.SupplierName,
                        CostPrice = item.CostPrice,
                        SellingPrice = item.SellingPrice,
                        ReorderLevel = item.ReorderLevel,
                        IsActive = item.IsActive,
                        CreatedDate = item.CreatedDate,
                        CurrentStock = currentStock
                    });
                }
            }

            return ApiResponse<IEnumerable<ItemDto>>.SuccessResponse(itemDtos);
        }

        public async Task<ApiResponse<ItemDto>> GetItemWithDetailsAsync(int id)
        {
            return await GetItemByIdAsync(id);
        }
    }
}