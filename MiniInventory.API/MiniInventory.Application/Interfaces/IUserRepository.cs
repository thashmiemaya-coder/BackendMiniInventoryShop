using MiniInventory.Domain.Entities;
using System.Threading.Tasks;

namespace MiniInventory.Application.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> GetUserByEmailAsync(string email);
        Task<bool> IsEmailExistsAsync(string email);
    }
}