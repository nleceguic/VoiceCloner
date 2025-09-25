using Microsoft.AspNetCore.Mvc;
using VoiceCloner.API.Data;
using VoiceCloner.Shared.Models;
using VoiceCloner.Shared.Models.DTOs;

namespace VoiceCloner.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VoicesController : ControllerBase
    {
        private readonly ApiContext _context;

        public VoicesController(ApiContext context) => _context = context;

        [HttpGet]
        public IActionResult GetAll() => Ok(_context.Voices.ToList());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var voice = _context.Voices.FirstOrDefault(v => v.VoiceId == id);
            return voice == null ? NotFound("Voz no encontrada.") : Ok(voice);
        }

        [HttpPost]
        public IActionResult Create([FromBody] VoiceCreateDTO dto)
        {
            var voice = new Voice
            {
                Name = dto.Name,
                Provider = dto.Provider,
                Language = dto.Language
            };

            _context.Voices.Add(voice);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = voice.VoiceId }, voice);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Voice voice)
        {
            var existing = _context.Voices.FirstOrDefault(v => v.VoiceId == id);
            if (existing == null) return NotFound("Voz no encontrada.");

            existing.Name = voice.Name;
            existing.Provider = voice.Provider;
            existing.ExternalId = voice.ExternalId;
            existing.Language = voice.Language;
            _context.SaveChanges();

            return Ok(existing);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var voice = _context.Voices.FirstOrDefault(v => v.VoiceId == id);
            if (voice == null) return NotFound("Voz no encontrada.");

            _context.Voices.Remove(voice);
            _context.SaveChanges();
            return NoContent();
        }
    }
}