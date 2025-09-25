using VoiceCloner.Shared.Models;
using VoiceCloner.Shared.Models.DTOs;

namespace VoiceCloner.API.Services
{
    public interface IVoiceRequestService
    {
        Task<List<VoiceRequestDto>> GetAllAsync();
        Task<VoiceRequestDto?> GetByIdAsync(int id);
        Task<VoiceRequestDto> CreateAsync(VoiceRequestCreateDto dto);
        Task<bool> DeleteAsync(int id);

        Task<List<VoiceRequestDto>> GetByUserIdAsync(int userId);
        Task<List<VoiceRequestDto>> GetByVoiceIdAsync(int voiceId);
        Task<List<VoiceRequestDto>> GetRecentRequestsAsync(int count = 10);

        Task<VoiceRequestDto> ProcessRequestAsync(VoiceRequestCreateDto dto);
        // Con este metodo se invoca ElevenLabs.

        Task<int> CountAsync();
        Task<int> CountByUserAsync(int userId);
        Task<int> CountByVoiceAsync(int voiceId);
        Task<Dictionary<string, int>> CountByDayAsync(DateTime from, DateTime to);
    }
}
