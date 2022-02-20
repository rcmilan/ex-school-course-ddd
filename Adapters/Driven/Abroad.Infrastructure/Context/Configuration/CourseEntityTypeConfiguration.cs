using Abroad.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Abroad.Infrastructure.Context.Configuration
{
    internal class CourseEntityTypeConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.CourseId);
            builder.OwnsOne(c => c.Id);
            builder.OwnsOne(c => c.ParentId);
            builder.Property(c => c.Name);
        }
    }
}
