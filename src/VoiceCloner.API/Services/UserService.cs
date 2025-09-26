using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using VoiceCloner.API.Data;
using VoiceCloner.API.Services;
using VoiceCloner.Shared.Models;
using VoiceCloner.Shared.Models.DTOs;
public class UserService : IUserService
{
    private readonly ApiContext _context;

    public UserService(ApiContext context) => _context = context;

    public async Task<List<UserDto>> GetAllAsync()
    {
        return await _context.Users
            .Select(u => new UserDto { UserId = u.UserId, Username = u.Username, Email = u.Email, Role = u.Role, CreatedAt = u.CreatedAt })
            .ToListAsync();
    }

    public async Task<UserDto?> GetByIdAsync(int id)
    {
        var u = await _context.Users.FindAsync(id);
        if (u == null) return null;
        return new UserDto { UserId = u.UserId, Username = u.Username, Email = u.Email, Role = u.Role, CreatedAt = u.CreatedAt };
    }

    public async Task<UserDto> CreateAsync(UserCreateDto dto)
    {
        var user = new User
        {
            Username = dto.Username,
            Email = dto.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            Role = string.IsNullOrWhiteSpace(dto.Role) ? "User" : dto.Role,
            CreatedAt = DateTime.UtcNow
        };
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return new UserDto
        {
            UserId = user.UserId,
            Username = user.Username,
            Email = user.Email,
            Role = user.Role,
            CreatedAt = user.CreatedAt
        };
    }

    public async Task<UserDto?> UpdateAsync(int id, UserUpdateDto dto)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null) return null;

        if (!string.IsNullOrWhiteSpace(dto.Username))
            user.Username = dto.Username;

        if (!string.IsNullOrWhiteSpace(dto.Email))
            user.Email = dto.Email;

        if (!string.IsNullOrWhiteSpace(dto.Password))
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

        if (!string.IsNullOrWhiteSpace(dto.Role))
            user.Role = dto.Role;

        await _context.SaveChangesAsync();

        return new UserDto
        {
            UserId = user.UserId,
            Username = user.Username,
            Email = user.Email,
            Role = user.Role,
            CreatedAt = user.CreatedAt
        };
    }



    public async Task<bool> DeleteAsync(int id)
    {
        var u = await _context.Users.FindAsync(id);
        if (u == null) return false;
        _context.Users.Remove(u);
        await _context.SaveChangesAsync();
        return true;
    }
}