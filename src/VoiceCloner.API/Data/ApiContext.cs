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
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(u => u.PasswordHash)
                .HasColumnName("PasswordHash")
                .HasMaxLength(200)
                .IsRequired();
            });
        }
    }
}