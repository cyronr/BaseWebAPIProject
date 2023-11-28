using AutoMapper;
using Application.Features.AuthenticationFeatures.Common;
using ProfileEntity = Domain.Models.ProfileModels.Profile;

namespace Application.Common.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            ///Profiles
            CreateMap<ProfileEntity, ProfileDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.UUID))
                .ForMember(d => d.ProfileType, opt => opt.MapFrom(s => s.Type));
        }
    }
}