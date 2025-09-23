using Microsoft.EntityFrameworkCore;
using VoiceCloner.Shared.Models;

namespace VoiceCloner.API.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<User> Urls { get; set; }
        public DbSet<Voice> UrlAccessLogs { get; set; }
        public DbSet<VoiceRequest>UrlAccessLogs { get; set; }
        public DbSet<VoiceResponse> UrlAccessLogs { get; set; }
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {

        }
    }
}