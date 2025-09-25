using System.ComponentModel.DataAnnotations;

namespace VoiceCloner.Shared.Models.DTOs
{
    /// <summary>
    /// DTO para actualizar datos de usuario.
    /// </summary>
    public class UserUpdateDto
    {
        [StringLength(50, MinimumLength = 3)]
        public string? Username { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
    }
}