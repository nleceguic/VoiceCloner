using System.ComponentModel.DataAnnotations;

namespace VoiceCloner.Shared.Models.DTOs
{
    /// <summary>
    /// DTO para registrar una nueva respuesta de voz (audio generado).
    /// </summary>
    public class VoiceResponseCreateDto
    {
        [Required]
        public int VoiceRequestId { get; set; }

        [Required]
        public string AudioBase64 { get; set; } = string.Empty;

        [Required]
        [StringLength(10)]
        public string AudioFormat { get; set; } = "wav";

        public decimal? DurationSeconds { get; set; }
    }
}
