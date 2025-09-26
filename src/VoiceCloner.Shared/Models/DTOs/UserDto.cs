namespace VoiceCloner.Shared.Models.DTOs
{
    /// <summary>
    /// DTO para exponer información de usuario al cliente.
    /// </summary>
    public class UserDto
    {
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string Role { get; set; } = "User";
        public DateTime? CreatedAt { get; set; }
    }
}