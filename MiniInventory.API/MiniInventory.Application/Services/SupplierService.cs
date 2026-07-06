using MiniInventory.Application.DTOs;
using MiniInventory.Application.Interfaces;
using MiniInventory.Domain.Entities;
using MiniInventory.Shared.CommonResponse;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniInventory.Application.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<ApiResponse<IEnumerable<SupplierDto>>> GetAllSuppliersAsync()
        {
            var suppliers = await _supplierRepository.GetAllAsync();
            var supplierDtos = suppliers.Select(s => new SupplierDto
            {
                SupplierId = s.SupplierId,
                SupplierName = s.SupplierName,
                ContactNumber = s.ContactNumber,
                Email = s.Email,
                Address = s.Address,
                IsActive = s.IsActive,
                CreatedDate = s.CreatedDate
            });
            return ApiResponse<IEnumerable<SupplierDto>>.SuccessResponse(supplierDtos);
        }

        public async Task<ApiResponse<SupplierDto>> GetSupplierByIdAsync(int id)
        {
            var supplier = await _supplierRepository.GetByIdAsync(id);
            if (supplier == null)
                return ApiResponse<SupplierDto>.ErrorResponse("Supplier not found");

            var supplierDto = new SupplierDto
            {
                SupplierId = supplier.SupplierId,
                SupplierName = supplier.SupplierName,
                ContactNumber = supplier.ContactNumber,
                Email = supplier.Email,
                Address = supplier.Address,
                IsActive = supplier.IsActive,
                CreatedDate = supplier.CreatedDate
            };
            return ApiResponse<SupplierDto>.SuccessResponse(supplierDto);
        }

        public async Task<ApiResponse<SupplierDto>> CreateSupplierAsync(SupplierCreateDto supplierDto)
        {
            var supplier = new Supplier
            {
                SupplierName = supplierDto.SupplierName,
                ContactNumber = supplierDto.ContactNumber,
                Email = supplierDto.Email,
                Address = supplierDto.Address,
                IsActive = supplierDto.IsActive
            };

            var created = await _supplierRepository.AddAsync(supplier);

            var result = new SupplierDto
            {
                SupplierId = created.SupplierId,
                SupplierName = created.SupplierName,
                ContactNumber = created.ContactNumber,
                Email = created.Email,
                Address = created.Address,
                IsActive = created.IsActive,
                CreatedDate = created.CreatedDate
            };
            return ApiResponse<SupplierDto>.SuccessResponse(result, "Supplier created successfully");
        }

        public async Task<ApiResponse<SupplierDto>> UpdateSupplierAsync(SupplierUpdateDto supplierDto)
        {
            var supplier = await _supplierRepository.GetByIdAsync(supplierDto.SupplierId);
            if (supplier == null)
                return ApiResponse<SupplierDto>.ErrorResponse("Supplier not found");

            supplier.SupplierName = supplierDto.SupplierName;
            supplier.ContactNumber = supplierDto.ContactNumber;
            supplier.Email = supplierDto.Email;
            supplier.Address = supplierDto.Address;
            supplier.IsActive = supplierDto.IsActive;

            await _supplierRepository.UpdateAsync(supplier);

            var result = new SupplierDto
            {
                SupplierId = supplier.SupplierId,
                SupplierName = supplier.SupplierName,
                ContactNumber = supplier.ContactNumber,
                Email = supplier.Email,
                Address = supplier.Address,
                IsActive = supplier.IsActive,
                CreatedDate = supplier.CreatedDate
            };
            return ApiResponse<SupplierDto>.SuccessResponse(result, "Supplier updated successfully");
        }

        public async Task<ApiResponse<bool>> DeleteSupplierAsync(int id)
        {
            var supplier = await _supplierRepository.GetByIdAsync(id);
            if (supplier == null)
                return ApiResponse<bool>.ErrorResponse("Supplier not found");

            await _supplierRepository.DeleteAsync(id);
            return ApiResponse<bool>.SuccessResponse(true, "Supplier deleted successfully");
        }

        public async Task<ApiResponse<IEnumerable<SupplierDto>>> SearchSuppliersAsync(string keyword)
        {
            var suppliers = await _supplierRepository.SearchByNameAsync(keyword);
            var supplierDtos = suppliers.Select(s => new SupplierDto
            {
                SupplierId = s.SupplierId,
                SupplierName = s.SupplierName,
                ContactNumber = s.ContactNumber,
                Email = s.Email,
                Address = s.Address,
                IsActive = s.IsActive,
                CreatedDate = s.CreatedDate
            });
            return ApiResponse<IEnumerable<SupplierDto>>.SuccessResponse(supplierDtos);
        }

        public async Task<ApiResponse<IEnumerable<SupplierDto>>> GetActiveSuppliersAsync()
        {
            var suppliers = await _supplierRepository.GetActiveSuppliersAsync();
            var supplierDtos = suppliers.Select(s => new SupplierDto
            {
                SupplierId = s.SupplierId,
                SupplierName = s.SupplierName,
                ContactNumber = s.ContactNumber,
                Email = s.Email,
                Address = s.Address,
                IsActive = s.IsActive,
                CreatedDate = s.CreatedDate
            });
            return ApiResponse<IEnumerable<SupplierDto>>.SuccessResponse(supplierDtos);
        }
    }
}