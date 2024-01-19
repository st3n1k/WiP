using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WiP.Core.Entity;

namespace WiP.Infrastructure.Data.Context
{
    public class WiPContext : DbContext
    {
        public WiPContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<GameEntity> Games { get; set; }
        public DbSet<DeveloperEntity> Developers { get; set; }
        public DbSet<PublisherEntity> Publishers { get; set; }
        public DbSet<GenreEntity> Genres { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
