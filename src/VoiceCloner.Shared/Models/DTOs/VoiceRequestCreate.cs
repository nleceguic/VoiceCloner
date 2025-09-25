using System.ComponentModel.DataAnnotations;

namespace VoiceCloner.Shared.Models.DTOs
{
    /// <summary>
    /// DTO para crear una nueva solicitud de voz.
    /// </summary>
    public class VoiceRequestCreateDto
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int VoiceId { get; set; }

        [Required]
        [StringLength(500)]
        public string InputText { get; set; } = string.Empty;
    }
}