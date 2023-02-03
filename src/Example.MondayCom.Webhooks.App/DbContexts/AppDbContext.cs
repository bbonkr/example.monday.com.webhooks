using Example.MondayCom.Webhooks.App.Entities;
using Microsoft.EntityFrameworkCore;

namespace Example.MondayCom.Webhooks.App.DbContexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
    {

    }

    public DbSet<MondayComRequest> Requests => Set<MondayComRequest>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            GetType().Assembly,
            t => t.Namespace?.Equals("Example.MondayCom.Webhooks.App.DbContexts.EntityTypeConfigurations", StringComparison.OrdinalIgnoreCase) ?? false);
    }
}
