using Microsoft.EntityFrameworkCore;
using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.ConfigTypes
{
  public class ActivityEntityTypeConfiguration : IEntityTypeConfiguration<Activity>
  {
    public void Configure(EntityTypeBuilder<Activity> builder)
    {
      builder.HasKey(a => a.Id);
      builder.Property(a => a.Title).IsRequired().HasMaxLength(50);
      builder.Property(a => a.Description).IsRequired().HasMaxLength(200);
      builder.Property(a => a.Category).IsRequired().HasMaxLength(50);
      builder.Property(a => a.City).IsRequired().HasMaxLength(50);
      builder.Property(a => a.Venue).IsRequired();
      builder.Property(a => a.Date).IsRequired();
    }
  }
}