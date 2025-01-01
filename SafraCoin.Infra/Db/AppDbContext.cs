using Microsoft.EntityFrameworkCore;
using SafraCoin.Core.Models;
using FarmerModel = SafraCoin.Core.Models.Farmer;

namespace SafraCoin.Infra.Db;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(u => u.Email).IsUnique();
        });
    }
    
    public required DbSet<User> Users { get; set; }
    public required DbSet<Investor> Investors { get; set; }
    public required DbSet<FarmerModel> Farmers { get; set; }
}
