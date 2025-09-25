using System.ComponentModel.DataAnnotations;

namespace VoiceCloner.Shared.Models.DTOs
{
    /// <summary>
    /// DTO para actualizar datos de una voz.
    /// </summary>
    public class VoiceUpdateDto
    {
        [StringLength(100)]
        public string? Name { get; set; }

        [StringLength(50)]
        public string? Provider { get; set; }

        public string? ExternalId { get; set; }

        [StringLength(10)]
        public string? Language { get; set; }
    }
}