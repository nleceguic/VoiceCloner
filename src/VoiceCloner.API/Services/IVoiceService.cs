using VoiceCloner.Shared.Models;
using VoiceCloner.Shared.Models.DTOs;

namespace VoiceCloner.API.Services
{
    public interface IVoiceService
    {
        Task<List<VoiceDto>> GetAllAsync();
        Task<VoiceDto?> GetByIdAsync(int id);
        Task<VoiceDto> CreateAsync(VoiceCreateDto dto);
        Task<VoiceDto?> UpdateAsync(int id, VoiceUpdateDto dto);
        Task<bool> DeleteAsync(int id);

        Task<VoiceDto?> GetByExternalIdAsync(string externalId);
        Task<List<VoiceDto>> GetByLanguageAsync(string language);
        Task<List<VoiceDto>> GetByProviderAsync(string provider);

        Task<string?> RegisterWithProviderAsync(VoiceCreateDto dto); // devuelve ExternalId
        Task<bool> DeleteFromProviderAsync(string externalId);

        Task<int> CountAsync();
        Task<Dictionary<string, int>> CountByProviderAsync();
    }
}
