public class Voice
{
    public int VoiceId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Provider { get; set; } = "ElevenLabs";
    public string? ExternalId { get; set; }
    public string? Language { get; set; }
    public DateTime CreatedAt { get; set; }
}