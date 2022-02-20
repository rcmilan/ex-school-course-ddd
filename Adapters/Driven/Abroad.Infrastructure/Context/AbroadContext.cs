using Abroad.Domain.Entities;
using Abroad.Infrastructure.Context.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Abroad.Infrastructure.Context
{
    public class AbroadContext : DbContext
    {
        public AbroadContext(DbContextOptions<AbroadContext> options) : base(options)
        {
            Database.EnsureCreated();
            Database.Migrate();
        }

        public DbSet<School> Schools { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new SchoolEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CourseEntityTypeConfiguration());
        }
    }
}
