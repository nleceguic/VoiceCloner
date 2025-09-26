using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

public class ElevenLabsCloningService : IVoiceCloningService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _config;

    public ElevenLabsCloningService(HttpClient httpClient, IConfiguration config)
    {
        _httpClient = httpClient;
        _config = config;
        _httpClient.BaseAddress = new Uri("https://api.elevenlabs.io/v1/");
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _config["ElevenLabs:ApiKey"]);
    }

    public async Task<string> CreateVoiceAsync(string name, string language, string audioBase64)
    {
        var requestBody = new
        {
            name = name,
            language = language,
            audio = audioBase64
        };

        var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("voices", content);

        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadFromJsonAsync<JsonElement>();
        return result.GetProperty("voice_id").GetString()!;
    }
}