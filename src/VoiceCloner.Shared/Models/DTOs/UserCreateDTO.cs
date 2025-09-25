namespace VoiceCloner.Shared.Models.DTOs
{
    public class UserCreateDto
    {
        public string Username { get; set; } = string.Empty;
        public string? Email { get; set; }
    }
}