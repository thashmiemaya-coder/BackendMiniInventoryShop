using MiniInventory.Application.DTOs;
using MiniInventory.Application.Interfaces;
using MiniInventory.Domain.Entities;
using MiniInventory.Shared.CommonResponse;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniInventory.Application.Services
{
    public class StockService : IStockService
    {
        private readonly IStockInRepository _stockInRepository;
        private readonly IStockOutRepository _stockOutRepository;
        private readonly IItemRepository _itemRepository;
        private readonly ISupplierRepository _supplierRepository;

        public StockService(IStockInRepository stockInRepository, IStockOutRepository stockOutRepository,
                            IItemRepository itemRepository, ISupplierRepository supplierRepository)
        {
            _stockInRepository = stockInRepository;
            _stockOutRepository = stockOutRepository;
            _itemRepository = itemRepository;
            _supplierRepository = supplierRepository;
        }

        public async Task<ApiResponse<StockInDto>> AddStockInAsync(StockInCreateDto stockInDto)
        {
            var item = await _itemRepository.GetByIdAsync(stockInDto.ItemId);
            if (item == null)
                return ApiResponse<StockInDto>.ErrorResponse("Item not found");

            var supplier = await _supplierRepository.GetByIdAsync(stockInDto.SupplierId);
            if (supplier == null)
                return ApiResponse<StockInDto>.ErrorResponse("Supplier not found");

            var stockIn = new StockIn
            {
                ItemId = stockInDto.ItemId,
                SupplierId = stockInDto.SupplierId,
                Quantity = stockInDto.Quantity,
                CostPrice = stockInDto.CostPrice,
                StockInDate = stockInDto.StockInDate
            };

            var created = await _stockInRepository.AddAsync(stockIn);

            var result = new StockInDto
            {
                StockInId = created.StockInId,
                ItemId = created.ItemId,
                ItemName = item.ItemName,
                SupplierId = created.SupplierId,
                SupplierName = supplier.SupplierName,
                Quantity = created.Quantity,
                CostPrice = created.CostPrice,
                StockInDate = created.StockInDate,
                CreatedDate = created.CreatedDate
            };
            return ApiResponse<StockInDto>.SuccessResponse(result, "Stock In added successfully");
        }

        public async Task<ApiResponse<StockOutDto>> AddStockOutAsync(StockOutCreateDto stockOutDto)
        {
            var item = await _itemRepository.GetByIdAsync(stockOutDto.ItemId);
            if (item == null)
                return ApiResponse<StockOutDto>.ErrorResponse("Item not found");

            var totalIn = await _stockInRepository.GetTotalStockInByItemAsync(stockOutDto.ItemId);
            var totalOut = await _stockOutRepository.GetTotalStockOutByItemAsync(stockOutDto.ItemId);
            var currentStock = totalIn - totalOut;

            if (currentStock < stockOutDto.Quantity)
                return ApiResponse<StockOutDto>.ErrorResponse("Insufficient stock available");

            var stockOut = new StockOut
            {
                ItemId = stockOutDto.ItemId,
                Quantity = stockOutDto.Quantity,
                Reason = stockOutDto.Reason,
                StockOutDate = stockOutDto.StockOutDate
            };

            var created = await _stockOutRepository.AddAsync(stockOut);

            var result = new StockOutDto
            {
                StockOutId = created.StockOutId,
                ItemId = created.ItemId,
                ItemName = item.ItemName,
                Quantity = created.Quantity,
                Reason = created.Reason,
                StockOutDate = created.StockOutDate,
                CreatedDate = created.CreatedDate
            };
            return ApiResponse<StockOutDto>.SuccessResponse(result, "Stock Out added successfully");
        }

        public async Task<ApiResponse<IEnumerable<StockInDto>>> GetStockInsByItemAsync(int itemId)
        {
            var stockIns = await _stockInRepository.GetStockInsByItemAsync(itemId);
            var stockInDtos = stockIns.Select(s => new StockInDto
            {
                StockInId = s.StockInId,
                ItemId = s.ItemId,
                ItemName = s.Item?.ItemName,
                SupplierId = s.SupplierId,
                SupplierName = s.Supplier?.SupplierName,
                Quantity = s.Quantity,
                CostPrice = s.CostPrice,
                StockInDate = s.StockInDate,
                CreatedDate = s.CreatedDate
            });
            return ApiResponse<IEnumerable<StockInDto>>.SuccessResponse(stockInDtos);
        }

        public async Task<ApiResponse<IEnumerable<StockOutDto>>> GetStockOutsByItemAsync(int itemId)
        {
            var stockOuts = await _stockOutRepository.GetStockOutsByItemAsync(itemId);
            var stockOutDtos = stockOuts.Select(s => new StockOutDto
            {
                StockOutId = s.StockOutId,
                ItemId = s.ItemId,
                ItemName = s.Item?.ItemName,
                Quantity = s.Quantity,
                Reason = s.Reason,
                StockOutDate = s.StockOutDate,
                CreatedDate = s.CreatedDate
            });
            return ApiResponse<IEnumerable<StockOutDto>>.SuccessResponse(stockOutDtos);
        }

        // ===== UPDATED: Added SupplierName mapping =====
        public async Task<ApiResponse<IEnumerable<StockBalanceDto>>> GetStockBalanceAsync()
        {
            var items = await _itemRepository.GetAllAsync();
            var stockBalances = new List<StockBalanceDto>();

            foreach (var item in items)
            {
                var totalIn = await _stockInRepository.GetTotalStockInByItemAsync(item.ItemId);
                var totalOut = await _stockOutRepository.GetTotalStockOutByItemAsync(item.ItemId);
                var currentBalance = totalIn - totalOut;

                string stockStatus;
                if (currentBalance <= 0)
                    stockStatus = "Out of Stock";
                else if (currentBalance <= item.ReorderLevel)
                    stockStatus = "Low Stock";
                else
                    stockStatus = "Good Stock";

                stockBalances.Add(new StockBalanceDto
                {
                    ItemId = item.ItemId,
                    ItemCode = item.ItemCode,
                    ItemName = item.ItemName,
                    CategoryName = item.Category?.CategoryName,
                    SupplierName = item.Supplier?.SupplierName,  // ← ADDED
                    TotalStockIn = totalIn,
                    TotalStockOut = totalOut,
                    CurrentBalance = currentBalance,
                    ReorderLevel = item.ReorderLevel,
                    StockStatus = stockStatus
                });
            }

            return ApiResponse<IEnumerable<StockBalanceDto>>.SuccessResponse(stockBalances);
        }

        public async Task<ApiResponse<IEnumerable<StockBalanceDto>>> GetLowStockItemsReportAsync()
        {
            var allBalances = await GetStockBalanceAsync();
            var lowStockItems = allBalances.Data?.Where(s => s.StockStatus == "Low Stock" || s.StockStatus == "Out of Stock");

            return ApiResponse<IEnumerable<StockBalanceDto>>.SuccessResponse(lowStockItems ?? new List<StockBalanceDto>());
        }

        public async Task<ApiResponse<IEnumerable<StockInDto>>> GetAllStockInsAsync()
        {
            var stockIns = await _stockInRepository.GetAllStockInsWithDetailsAsync();
            var stockInDtos = stockIns.Select(s => new StockInDto
            {
                StockInId = s.StockInId,
                ItemId = s.ItemId,
                ItemName = s.Item?.ItemName ?? "Unknown Item",
                SupplierId = s.SupplierId,
                SupplierName = s.Supplier?.SupplierName ?? "Unknown Supplier",
                Quantity = s.Quantity,
                CostPrice = s.CostPrice,
                Total = s.Quantity * s.CostPrice,
                StockInDate = s.StockInDate,
                CreatedDate = s.CreatedDate,
            });
            return ApiResponse<IEnumerable<StockInDto>>.SuccessResponse(stockInDtos);
        }

        public async Task<ApiResponse<IEnumerable<StockOutDto>>> GetAllStockOutsAsync()
        {
            var stockOuts = await _stockOutRepository.GetAllStockOutsWithDetailsAsync();
            var stockOutDtos = stockOuts.Select(s => new StockOutDto
            {
                StockOutId = s.StockOutId,
                ItemId = s.ItemId,
                ItemName = s.Item?.ItemName ?? "Unknown Item",
                Quantity = s.Quantity,
                Reason = s.Reason,
                StockOutDate = s.StockOutDate,
                CreatedDate = s.CreatedDate
            });
            return ApiResponse<IEnumerable<StockOutDto>>.SuccessResponse(stockOutDtos);
        }
    }
}