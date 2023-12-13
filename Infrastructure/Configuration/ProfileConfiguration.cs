using Domain.Models.ProfileModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class ProfileConfiguration : IEntityTypeConfiguration<Profile>
{
    public void Configure(EntityTypeBuilder<Profile> builder)
    {
        builder.Property(p => p.Email).HasMaxLength(150);
        builder.Property(p => p.PhoneNumber).HasMaxLength(20);
    }
}
