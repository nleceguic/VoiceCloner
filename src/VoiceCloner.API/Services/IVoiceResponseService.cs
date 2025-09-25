using VoiceCloner.Shared.Models;
using VoiceCloner.Shared.Models.DTOs;

namespace VoiceCloner.API.Services
{
    public interface IVoiceResponseService
    {
        Task<VoiceResponseDto?> GetByIdAsync(int id);
        Task<List<VoiceResponseDto>> GetByRequestIdAsync(int requestId);
        Task<VoiceResponseDto> CreateAsync(VoiceResponseCreateDto dto);
        Task<bool> DeleteAsync(int id);

        Task<byte[]?> GetAudioBytesAsync(int id);
        Task<string?> GetAudioBase64Async(int id);
        Task<bool> SaveToFileAsync(int id, string filePath);

        Task<int> CountAsync();
        Task<decimal?> AverageDurationAsync();
    }
}
