using MiniInventory.Application.DTOs;
using MiniInventory.Application.Interfaces;
using MiniInventory.Domain.Entities;
using MiniInventory.Shared.CommonResponse;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniInventory.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ApiResponse<IEnumerable<CategoryDto>>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            var categoryDtos = categories.Select(c => new CategoryDto
            {
                CategoryId = c.CategoryId,
                CategoryName = c.CategoryName,
                Description = c.Description,
                IsActive = c.IsActive,
                CreatedDate = c.CreatedDate
            });
            return ApiResponse<IEnumerable<CategoryDto>>.SuccessResponse(categoryDtos);
        }

        public async Task<ApiResponse<CategoryDto>> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
                return ApiResponse<CategoryDto>.ErrorResponse("Category not found");

            var categoryDto = new CategoryDto
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                Description = category.Description,
                IsActive = category.IsActive,
                CreatedDate = category.CreatedDate
            };
            return ApiResponse<CategoryDto>.SuccessResponse(categoryDto);
        }

        public async Task<ApiResponse<CategoryDto>> CreateCategoryAsync(CategoryCreateDto categoryDto)
        {
            var category = new Category
            {
                CategoryName = categoryDto.CategoryName,
                Description = categoryDto.Description,
                IsActive = categoryDto.IsActive
            };

            var created = await _categoryRepository.AddAsync(category);

            var result = new CategoryDto
            {
                CategoryId = created.CategoryId,
                CategoryName = created.CategoryName,
                Description = created.Description,
                IsActive = created.IsActive,
                CreatedDate = created.CreatedDate
            };
            return ApiResponse<CategoryDto>.SuccessResponse(result, "Category created successfully");
        }

        public async Task<ApiResponse<CategoryDto>> UpdateCategoryAsync(CategoryUpdateDto categoryDto)
        {
            var category = await _categoryRepository.GetByIdAsync(categoryDto.CategoryId);
            if (category == null)
                return ApiResponse<CategoryDto>.ErrorResponse("Category not found");

            category.CategoryName = categoryDto.CategoryName;
            category.Description = categoryDto.Description;
            category.IsActive = categoryDto.IsActive;

            await _categoryRepository.UpdateAsync(category);

            var result = new CategoryDto
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                Description = category.Description,
                IsActive = category.IsActive,
                CreatedDate = category.CreatedDate
            };
            return ApiResponse<CategoryDto>.SuccessResponse(result, "Category updated successfully");
        }

        public async Task<ApiResponse<bool>> DeleteCategoryAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
                return ApiResponse<bool>.ErrorResponse("Category not found");

            await _categoryRepository.DeleteAsync(id);
            return ApiResponse<bool>.SuccessResponse(true, "Category deleted successfully");
        }

        public async Task<ApiResponse<IEnumerable<CategoryDto>>> SearchCategoriesAsync(string keyword)
        {
            var categories = await _categoryRepository.SearchByNameAsync(keyword);
            var categoryDtos = categories.Select(c => new CategoryDto
            {
                CategoryId = c.CategoryId,
                CategoryName = c.CategoryName,
                Description = c.Description,
                IsActive = c.IsActive,
                CreatedDate = c.CreatedDate
            });
            return ApiResponse<IEnumerable<CategoryDto>>.SuccessResponse(categoryDtos);
        }

        public async Task<ApiResponse<IEnumerable<CategoryDto>>> GetActiveCategoriesAsync()
        {
            var categories = await _categoryRepository.GetActiveCategoriesAsync();
            var categoryDtos = categories.Select(c => new CategoryDto
            {
                CategoryId = c.CategoryId,
                CategoryName = c.CategoryName,
                Description = c.Description,
                IsActive = c.IsActive,
                CreatedDate = c.CreatedDate
            });
            return ApiResponse<IEnumerable<CategoryDto>>.SuccessResponse(categoryDtos);
        }
    }
}