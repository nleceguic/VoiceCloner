namespace VoiceCloner.Shared.Models.DTOs
{
    /// <summary>
    /// DTO para mostrar respuestas de generación de voz.
    /// </summary>
    public class VoiceResponseDto
    {
        public int VoiceResponseId { get; set; }
        public int VoiceRequestId { get; set; }
        public string? AudioBase64 { get; set; }
        public string AudioFormat { get; set; } = "wav";
        public decimal? DurationSeconds { get; set; }
        public DateTime CreatedAt { get; set; }

        public VoiceRequestDto? Request { get; set; }
    }
}
