using System.ComponentModel.DataAnnotations;

namespace VoiceCloner.Shared.Models.DTOs
{
    /// <summary>
    /// DTO para actualizar datos de usuario. 
    /// </summary>
    public class UserUpdateDto
    {
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre de usuario debe tener entre 3 y 50 caracteres.")]
        public string? Username { get; set; }

        [EmailAddress(ErrorMessage = "El correo electrónico no tiene un formato válido.")]
        public string? Email { get; set; }

        [StringLength(100, MinimumLength = 6, ErrorMessage = "La contraseña debe tener entre 6 y 100 caracteres.")]
        public string? Password { get; set; }

        [StringLength(100)]
        public string? Role { get; set; }
    }
}
