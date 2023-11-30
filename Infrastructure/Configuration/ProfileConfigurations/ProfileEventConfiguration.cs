using Domain.Models.ProfileModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration.ProfileConfigurations;

public class ProfileEventConfiguration : IEntityTypeConfiguration<ProfileEvent>
{
    public void Configure(EntityTypeBuilder<ProfileEvent> builder)
    {
       
    }
}
