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
            //Database.Migrate();
        }

        public DbSet<School> Schools { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SchoolEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CourseEntityTypeConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
