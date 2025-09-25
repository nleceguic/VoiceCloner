using Microsoft.AspNetCore.Mvc;
using VoiceCloner.API.Data;
using VoiceCloner.Shared.Models;

namespace VoiceCloner.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ApiContext _context;

        public UsersController(ApiContext context) => _context = context;

        [HttpGet]
        public IActionResult GetAll() => Ok(_context.Users.ToList());

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == id);
            return user == null ? NotFound("Usuario no encontrado.") : Ok(user);
        }

        [HttpPost]
        public IActionResult Create([FromBody] User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = user.UserId }, user);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] User user)
        {
            var existing = _context.Users.FirstOrDefault(u => u.UserId == id);
            if (existing == null) return NotFound("Usuario no encontrado.");

            existing.Username = user.Username;
            existing.Email = user.Email;
            _context.SaveChanges();

            return Ok(existing);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == id);
            if (user == null) return NotFound("Usuario no encontrado.");

            _context.Users.Remove(user);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
