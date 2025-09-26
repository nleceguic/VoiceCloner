using VoiceCloner.Shared.Models;
using VoiceCloner.Shared.Models.DTOs;

namespace VoiceCloner.API.Services
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllAsync();
        Task<UserDto?> GetByIdAsync(int id);
        Task<UserDto> CreateAsync(UserCreateDto dto);
        Task<UserDto?> UpdateAsync(int id, UserUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}