using Application.Features.AuthenticationFeatures.Common;
using Mapster;
using WebAPI.Responses.AuthenticationResponses;

namespace WebAPI.Common;

internal static class MapsterConfiguration
{
    public static void RegisterMapsterConfiguration(this IServiceCollection services)
    {
        TypeAdapterConfig<ProfileDto, AuthenticationResponseProfile>.NewConfig()
            .Map(dest => dest.ProfileType.Id, src => (int)src.ProfileType)
            .Map(dest => dest.ProfileType.Name, src => src.ProfileType.ToString());
    }
}
