using Domain.Models.ProfileModels;
using Mapster;

namespace Domain.ModelsUpdateParams;

public record ProfileUpdateParams(
    byte[]? passwordSalt = default, 
    byte[]? passwordHash = default, 
    string? phoneNumber = default) : UpdateParams<ProfileUpdateParams, Profile>;
