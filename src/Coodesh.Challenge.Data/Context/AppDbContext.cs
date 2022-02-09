using Coodesh.Challenge.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace Coodesh.Challenge.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Launch> Launches { get; set; }
        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}