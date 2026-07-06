using MiniInventory.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiniInventory.Application.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<IEnumerable<Category>> SearchByNameAsync(string keyword);
        Task<IEnumerable<Category>> GetActiveCategoriesAsync();
    }
}