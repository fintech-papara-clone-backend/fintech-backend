using FintechBackend.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FintechBackend.Repositories;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("UsersTable");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=AuthenticationDb;User Id=sa;Password=Sevda.21;TrustServerCertificate=True;");
        }
    }
}