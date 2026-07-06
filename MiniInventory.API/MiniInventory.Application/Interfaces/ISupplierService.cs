using MiniInventory.Application.DTOs;
using MiniInventory.Shared.CommonResponse;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiniInventory.Application.Interfaces
{
    public interface ISupplierService
    {
        Task<ApiResponse<IEnumerable<SupplierDto>>> GetAllSuppliersAsync();
        Task<ApiResponse<SupplierDto>> GetSupplierByIdAsync(int id);
        Task<ApiResponse<SupplierDto>> CreateSupplierAsync(SupplierCreateDto supplierDto);
        Task<ApiResponse<SupplierDto>> UpdateSupplierAsync(SupplierUpdateDto supplierDto);
        Task<ApiResponse<bool>> DeleteSupplierAsync(int id);
        Task<ApiResponse<IEnumerable<SupplierDto>>> SearchSuppliersAsync(string keyword);
        Task<ApiResponse<IEnumerable<SupplierDto>>> GetActiveSuppliersAsync();
    }
}