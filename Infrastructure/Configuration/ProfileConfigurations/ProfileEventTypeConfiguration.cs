using Domain.Models.ProfileModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration.ProfileConfigurations;

public class ProfileEventTypeConfiguration : IEntityTypeConfiguration<ProfileEventTypeModel>
{
    public void Configure(EntityTypeBuilder<ProfileEventTypeModel> builder)
    {
        builder.Property(p => p.Name).HasMaxLength(50);

        /*builder
            .HasMany(s => s.Events)
            .WithOne(o => o.Type)
            .HasForeignKey(s => s.TypeId)
            .OnDelete(DeleteBehavior.NoAction);*/

        builder.HasData(Enum.GetValues(typeof(ProfileEventType))
            .Cast<ProfileEventType>()
            .Select(e => new ProfileEventTypeModel()
            {
                Id = Convert.ToInt32(e),
                Name = e.ToString()
            }));
    }
}
