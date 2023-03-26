using Microsoft.EntityFrameworkCore;
using Domain;
namespace Persistence
{
  public class DataContext : DbContext
  {

    public DataContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Activity> Activities { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
    }

  }
}