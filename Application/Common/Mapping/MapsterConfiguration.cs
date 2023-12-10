using Application.Features.AuthenticationFeatures.Common;
using Domain.Models.ProfileModels;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Application.Common.Mapping;

internal static class MapsterConfiguration
{
    public static void RegisterMapsterConfiguration(this IServiceCollection services)
    {
        TypeAdapterConfig<Profile, ProfileDto>.NewConfig()
            .Map(dest => dest.Id, src => src.UUID)
            .Map(dest => dest.ProfileType, src => src.Type);
    }
}
