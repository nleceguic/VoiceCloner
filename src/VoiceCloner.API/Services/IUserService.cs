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

        Task<UserDto?> GetByEmailAsync(string email);
        Task<bool> ExistsAsync(int id);
        Task<bool> ExistsByEmailAsync(string email);

        Task<List<UserDto>> SearchAsync(string query, int page = 1, int pageSize = 20);

        Task<int> CountAsync();
        Task<Dictionary<string, int>> CountByMonthAsync(int year);
    }
}