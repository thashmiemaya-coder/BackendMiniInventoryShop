using MiniInventory.Application.DTOs;
using MiniInventory.Shared.CommonResponse;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiniInventory.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<ApiResponse<IEnumerable<CategoryDto>>> GetAllCategoriesAsync();
        Task<ApiResponse<CategoryDto>> GetCategoryByIdAsync(int id);
        Task<ApiResponse<CategoryDto>> CreateCategoryAsync(CategoryCreateDto categoryDto);
        Task<ApiResponse<CategoryDto>> UpdateCategoryAsync(CategoryUpdateDto categoryDto);
        Task<ApiResponse<bool>> DeleteCategoryAsync(int id);
        Task<ApiResponse<IEnumerable<CategoryDto>>> SearchCategoriesAsync(string keyword);
        Task<ApiResponse<IEnumerable<CategoryDto>>> GetActiveCategoriesAsync();
    }
}