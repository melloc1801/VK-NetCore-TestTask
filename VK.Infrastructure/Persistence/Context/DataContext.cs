using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using VK.Domain.Entities;

namespace VK.Infrastructure.Persistence.Context;

public class DataContext: DbContext
{

    public DataContext()
    {
    }
    
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
        
    } 
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseNpgsql(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(user => user.Login).IsUnique();
        });
    }

    public DbSet<User> Users { get; set; }
    public DbSet<UserGroup> UserGroups { get; set; }
    public DbSet<UserState> UserStates { get; set; }
}