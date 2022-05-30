using BlazorAndSQLite.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorAndSQLite
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Settings> Settings { get; set; } = default!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { 
        
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
