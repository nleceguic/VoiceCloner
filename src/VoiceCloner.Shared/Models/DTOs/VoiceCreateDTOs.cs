namespace VoiceCloner.Shared.Models.DTOs
{
    public class VoiceCreateDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Provider { get; set; } = "ElevenLabs";
        public string? ExternalId { get; set; }
        public string? Language { get; set; }
    }
}