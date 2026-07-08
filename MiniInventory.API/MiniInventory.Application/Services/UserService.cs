using MiniInventory.Application.DTOs;
using MiniInventory.Application.Interfaces;
using MiniInventory.Domain.Entities;
using MiniInventory.Shared.CommonResponse;
using System.Threading.Tasks;

namespace MiniInventory.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ApiResponse<LoginResponseDto>> LoginAsync(LoginRequestDto request)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Email);

            if (user == null)
            {
                return ApiResponse<LoginResponseDto>.ErrorResponse("Invalid email or password");
            }

            // Simple password check (in production, use BCrypt or similar)
            if (user.PasswordHash != request.Password)
            {
                return ApiResponse<LoginResponseDto>.ErrorResponse("Invalid email or password");
            }

            var response = new LoginResponseDto
            {
                Success = true,
                Message = "Login successful",
                Token = "demo-jwt-token", // In production, generate a real JWT
                Role = user.Role,
                UserName = user.FullName,
                Email = user.Email
            };

            return ApiResponse<LoginResponseDto>.SuccessResponse(response);
        }

        public async Task<ApiResponse<UserDto>> RegisterAsync(CreateUserDto request)
        {
            // Check if email exists
            if (await _userRepository.IsEmailExistsAsync(request.Email))
            {
                return ApiResponse<UserDto>.ErrorResponse("Email already exists");
            }

            var user = new User
            {
                Username = request.Username,
                Email = request.Email,
                PasswordHash = request.Password, // In production, hash this
                Role = request.Role,
                FullName = request.FullName,
                IsActive = true,
                CreatedDate = System.DateTime.Now
            };

            var created = await _userRepository.AddAsync(user);

            var userDto = new UserDto
            {
                UserId = created.UserId,
                Username = created.Username,
                Email = created.Email,
                Role = created.Role,
                FullName = created.FullName,
                IsActive = created.IsActive,
                CreatedDate = created.CreatedDate
            };

            return ApiResponse<UserDto>.SuccessResponse(userDto, "User registered successfully");
        }

        public async Task<ApiResponse<UserDto>> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return ApiResponse<UserDto>.ErrorResponse("User not found");
            }

            var userDto = new UserDto
            {
                UserId = user.UserId,
                Username = user.Username,
                Email = user.Email,
                Role = user.Role,
                FullName = user.FullName,
                IsActive = user.IsActive,
                CreatedDate = user.CreatedDate
            };

            return ApiResponse<UserDto>.SuccessResponse(userDto);
        }

        public async Task<ApiResponse<UserDto>> GetUserByEmailAsync(string email)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);
            if (user == null)
            {
                return ApiResponse<UserDto>.ErrorResponse("User not found");
            }

            var userDto = new UserDto
            {
                UserId = user.UserId,
                Username = user.Username,
                Email = user.Email,
                Role = user.Role,
                FullName = user.FullName,
                IsActive = user.IsActive,
                CreatedDate = user.CreatedDate
            };

            return ApiResponse<UserDto>.SuccessResponse(userDto);
        }
    }
}