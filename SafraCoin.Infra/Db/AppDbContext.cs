using Microsoft.EntityFrameworkCore;
using SafraCoin.Core.Models;

namespace SafraCoin.Infra.Db;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
    
    public required DbSet<User> Users { get; set; }
    public required DbSet<Investor> Investors { get; set; }
}
