using Microsoft.AspNetCore.Mvc;
using VoiceCloner.Shared.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using VoiceCloner.API.Data;

namespace VoiceCloner.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VoiceController : ControllerBase
    {
        private readonly ApiContext _context;

        public VoiceController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/voice/{id}
        [HttpGet("voices/{id}")]
        public IActionResult GetById(int id)
        {
            var voice = _context.Voices.Find(id);

            if (voice == null)
            {
                return NotFound("Voz no encontrada.");
            }

            return Ok(new
            {
                id = voice.VoiceId,
                name = voice.Name,
                provider = voice.Provider,
                externalId = voice.ExternalId,
                language = voice.Language,
                createdAt = voice.CreatedAt
            });
        }
    }
}