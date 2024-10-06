using Microsoft.EntityFrameworkCore;
using UrbanJungleRealty.Domain.Model.Estates;
using UrbanJungleRealty.Domain.Model.Profile;

namespace UrbanJungleRealty.Infrastruture.Data.ApplicationDbContexts;

public class ApplicationDbContext : DbContext
{
    public DbSet<Apartment> Properties { get; set; }
    public DbSet<User> Users { get; set; }

    public ApplicationDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
