using CargoApi.Application.DTOs;
using static CargoApi.Domain.Enums.UserEnums;


namespace CargoApi.Application.Interfaces.Services
{
    public interface IUserService
    {

        Task<UserResponseDto> GetUserByIdAsync(int id);
        Task<UserResponseDto> GetUserByExternalIdAsync(string externalId);
        Task<UserResponseDto> GetUserByEmailAsync(string email);
        Task<IEnumerable<UserResponseDto>> GetAllUsersAsync();
        Task<IEnumerable<UserResponseDto>> GetUsersByStatusAsync(UserStatus status);
        Task<UserResponseDto> CreateUserAsync(CreateUserRequestDto userDto);
        Task UpdateUserAsync(int id, UpdateUserRequestDto userDto);
        Task DeleteUserAsync(int id);
        Task SoftDeleteUserAsync(int id);
        Task ChangeUserStatusAsync(int id, UserStatus status);
        Task CompleteRegistrationAsync(int userId, string userType, CompleteRegistrationRequestDto registrationDto);
    }
}
