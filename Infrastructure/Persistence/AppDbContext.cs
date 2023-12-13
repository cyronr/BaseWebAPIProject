using Domain.Models.ProfileModels;
using Infrastructure.Common.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    private readonly ConnectionStrings _connectionStrings;

    public AppDbContext(DbContextOptions<AppDbContext> options, IOptions<ConnectionStrings> connectionOptions) : base(options)
    {
        _connectionStrings = connectionOptions.Value;
    }


    //Profiles
    public DbSet<Profile> Profiles { get; set; }
    public DbSet<ProfileEvent> ProfileEvents { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_connectionStrings.DefaultConnection);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}