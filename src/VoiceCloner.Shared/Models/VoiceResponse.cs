namespace VoiceCloner.Shared.Models
{
    public class VoiceResponse
    {
        public int VoiceResponseId { get; set; }
        public int VoiceRequestId { get; set; }
        public string? AudioBase64 { get; set; }
        public string AudioFormat { get; set; } = "wav";
        public decimal? DurationSeconds { get; set; }
        public DateTime CreatedAt { get; set; }
        public VoiceRequest? Request { get; set; }
    }
}