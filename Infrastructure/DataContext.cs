using Domain.Models.ProfileModels;
using Infrastructure.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Infrastructure.Data
{
    public class DataContext : DbContext
    {
        private readonly ConnectionStrings _connectionStrings;

        public DataContext(DbContextOptions<DataContext> options, IOptions<ConnectionStrings> connectionOptions) : base(options)
        {
            _connectionStrings = connectionOptions.Value;
        }

       

        //Profiles
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<ProfileStatusModel> ProfileStatus { get; set; }
        public DbSet<ProfileTypeModel> ProfileType { get; set; }
        public DbSet<ProfileEvent> ProfileEvents { get; set; }
        public DbSet<ProfileEventTypeModel> ProfileEventType { get; set; }

       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionStrings.DefaultConnection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }
    }
}