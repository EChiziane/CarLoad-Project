using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class DataContext : IdentityDbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Guest> Guests { get; set; }
    public DbSet<Sprint> Sprints { get; set; }
    public DbSet<CarLoad> CarLoads { get; set; }
    public DbSet<Driver> Drivers { get; set; }
    public DbSet<Material> Materials { get; set; }
    public DbSet<Manager> Managers { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<SystemLanguage> SystemLanguages { get; set; }
}