using AutoMapper;
using Application.Features.AuthenticationFeatures.Common;
using API.Requests.AuthenticationResponses;

namespace API.Common.Mapping;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        ///Authentication mappings
        CreateMap<AuthenticationResultDto, AuthenticationResponse>();
    }   
}