using System.ComponentModel.DataAnnotations;

namespace VoiceCloner.Shared.Models.DTOs
{
    /// <summary>
    /// DTO para registrar un nuevo usuario.
    /// </summary>
    public class UserCreateDto
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Username { get; set; } = string.Empty;

        [EmailAddress]
        public string? Email { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres.")]
        public string Password { get; set; } = string.Empty;

        public string Role { get; set; } = "User";
    }
}