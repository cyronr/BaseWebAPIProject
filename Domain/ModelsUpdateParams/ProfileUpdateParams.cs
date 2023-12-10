using Domain.Models.ProfileModels;

namespace Domain.ModelsUpdateParams;

public record ProfileUpdateParams(
    byte[]? passwordSalt = default, 
    byte[]? passwordHash = default, 
    string? phoneNumber = default) : UpdateParams<ProfileUpdateParams, Profile>;
