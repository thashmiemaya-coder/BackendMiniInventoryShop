using MiniInventory.Application.DTOs;
using MiniInventory.Shared.CommonResponse;
using System.Threading.Tasks;

namespace MiniInventory.Application.Interfaces
{
    public interface IUserService
    {
        Task<ApiResponse<LoginResponseDto>> LoginAsync(LoginRequestDto request);
        Task<ApiResponse<UserDto>> RegisterAsync(CreateUserDto request);
        Task<ApiResponse<UserDto>> GetUserByIdAsync(int id);
        Task<ApiResponse<UserDto>> GetUserByEmailAsync(string email);
    }
}