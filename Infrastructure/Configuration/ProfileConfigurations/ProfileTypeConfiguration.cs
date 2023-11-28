using Domain.Models.ProfileModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration.ProfileConfigurations;

public class ProfileTypeConfiguration : IEntityTypeConfiguration<ProfileTypeModel>
{
    public void Configure(EntityTypeBuilder<ProfileTypeModel> builder)
    {
        builder.Property(p => p.Name).HasMaxLength(50);

        /* builder
             .HasMany(s => s.Profiles)
             .WithOne(o => o.Type)
             .HasForeignKey(s => s.TypeId)
             .OnDelete(DeleteBehavior.NoAction);*/

        builder.HasData(Enum.GetValues(typeof(ProfileType))
            .Cast<ProfileType>()
            .Select(e => new ProfileTypeModel()
            {
                Id = Convert.ToInt32(e),
                Name = e.ToString()
            }));
    }
}
