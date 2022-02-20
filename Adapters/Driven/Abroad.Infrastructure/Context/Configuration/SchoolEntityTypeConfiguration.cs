using Abroad.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Abroad.Infrastructure.Context.Configuration
{
    internal class SchoolEntityTypeConfiguration : IEntityTypeConfiguration<School>
    {
        public void Configure(EntityTypeBuilder<School> builder)
        {
            builder.HasKey(s => s.SchoolId);
            builder.OwnsOne(s => s.Id);
            builder.Property(s => s.Name);
        }
    }
}
