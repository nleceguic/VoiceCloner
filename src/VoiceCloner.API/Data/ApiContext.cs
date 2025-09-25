using Microsoft.EntityFrameworkCore;
using VoiceCloner.Shared.Models;

namespace VoiceCloner.API.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Voice> Voices { get; set; }
        public DbSet<VoiceRequest> VoiceRequests { get; set; }
        public DbSet<VoiceResponse> VoiceResponses { get; set; }
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {

        }
    }
}