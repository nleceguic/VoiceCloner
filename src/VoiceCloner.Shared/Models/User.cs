namespace VoiceCloner.Shared.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string? Email { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string PasswordHash { get; set; } = string.Empty;
    }
}