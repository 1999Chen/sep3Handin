using Microsoft.EntityFrameworkCore;
using sep3tier3.Models;

namespace sep3tier3.DataAccess
{
    public class sepDBContext : DbContext
    {
        public DbSet<User>Users { set; get; }
        public DbSet<ChatMessage>ChatMessages { set; get; }
        public DbSet<Friend>Friends { set; get; }
  

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = ./sep.db");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Friend>()
                .HasKey(c => new { c.username1, c.username2 });
        }
        
        
    }
}