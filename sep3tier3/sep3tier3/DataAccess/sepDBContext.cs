using Microsoft.EntityFrameworkCore;
using sep3tier3.Models;

namespace sep3tier3.DataAccess
{
    public class sepDBContext:DbContext
    {
        public DbSet<Friend> Friends { get; set; }
        public DbSet<User>Users { get; set; }
        public DbSet<SocialLine> SocialLines { get; set; }
        public DbSet<ChatMessage>ChatMessages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:/Users/yu/Desktop/sep.db");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Friend>()
                .HasKey(c => new { c.username1, c.username2 });
        }
        
        
        
        
        
        
    }
}