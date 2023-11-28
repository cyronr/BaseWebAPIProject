using Domain.Models.ProfileModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration.ProfileConfigurations;

public class ProfileStatusConfiguration : IEntityTypeConfiguration<ProfileStatusModel>
{
    public void Configure(EntityTypeBuilder<ProfileStatusModel> builder)
    {
        builder.Property(p => p.Name).HasMaxLength(50);

        /*builder
            .HasMany(s => s.Profiles)
            .WithOne(o => o.Status)
            .HasForeignKey(s => s.StatusId)
            .OnDelete(DeleteBehavior.NoAction);*/

        builder.HasData( Enum.GetValues(typeof(ProfileStatus))
            .Cast<ProfileStatus>()
            .Select(e => new ProfileStatusModel()
            {
                Id = Convert.ToInt32(e),
                Name = e.ToString()
            }));
    }
}
