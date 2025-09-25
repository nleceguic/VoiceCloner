namespace VoiceCloner.Shared.Models
{
    public class VoiceRequest
    {
        public int VoiceRequestId { get; set; }
        public int? UserId { get; set; }
        public int? VoiceId { get; set; }
        public string InputText { get; set; } = string.Empty;
        public bool Success { get; set; }
        public string? Message { get; set; }
        public DateTime CreatedAt { get; set; }
        public User? User { get; set; }
        public Voice? Voice { get; set; }
        public ICollection<VoiceResponse> Responses { get; set; } = new List<VoiceResponse>();
    }
}