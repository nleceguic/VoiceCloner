namespace VoiceCloner.Shared.Models.DTOs
{
    /// <summary>
    /// DTO para mostrar solicitudes de generación de voz.
    /// </summary>
    public class VoiceRequestDto
    {
        public int VoiceRequestId { get; set; }
        public int? UserId { get; set; }
        public int? VoiceId { get; set; }
        public string InputText { get; set; } = string.Empty;
        public bool Success { get; set; }
        public string? Message { get; set; }
        public DateTime CreatedAt { get; set; }

        public UserDto? User { get; set; }
        public VoiceDto? Voice { get; set; }
    }
}