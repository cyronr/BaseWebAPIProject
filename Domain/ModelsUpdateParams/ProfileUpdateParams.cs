using Domain.Models.ProfileModels;

namespace Domain.ModelsUpdateParams;

/// <summary>
/// Update params used to update Profile entity
/// </summary>
/// <param name="passwordSalt"></param>
/// <param name="passwordHash"></param>
/// <param name="phoneNumber"></param>
public record ProfileUpdateParams(
    byte[]? passwordSalt = default, 
    byte[]? passwordHash = default, 
    string? phoneNumber = default) : UpdateParams<ProfileUpdateParams, Profile>;
