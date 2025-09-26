using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using VoiceCloner.Shared.Models.DTOs;
using VoiceCloner.Shared.Models;
using VoiceCloner.API.Services;

namespace VoiceCloner.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _service.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _service.GetByIdAsync(id);
            if (user == null)
                return NotFound("Usuario no encontrado.");

            if (User.Identity?.Name != user.Username && !User.IsInRole("Admin"))
                return Forbid();

            return Ok(user);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] UserCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _service.CreateAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = result.UserId }, result);
            }
            catch (Exception ex)
            {
                return Conflict(new { message = ex.Message });
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UserUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingUser = await _service.GetByIdAsync(id);
            if (existingUser == null)
                return NotFound("Usuario no encontrado.");

            if (User.Identity?.Name != existingUser.Username && !User.IsInRole("Admin"))
                return Forbid();

            try
            {
                var updated = await _service.UpdateAsync(id, dto);
                return Ok(updated);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success)
                return NotFound("Usuario no encontrado.");

            return NoContent();
        }
    }
}
