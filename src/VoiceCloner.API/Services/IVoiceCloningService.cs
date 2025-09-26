public interface IVoiceCloningService
{
    /// <summary>
    /// Entrena una nueva voz en ElevenLabs con el audio proporcionado.
    /// </summary>
    /// <param name="name">Nombre de la voz</param>
    /// <param name="language">Idioma</param>
    /// <param name="audioBase64">Audio del usuario en Base64</param>
    /// <returns>ExternalId de la voz creada</returns>
    Task<string> CreateVoiceAsync(string name, string language, string audioBase64);
}