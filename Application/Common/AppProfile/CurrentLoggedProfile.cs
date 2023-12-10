using Application.Persistence.Repositories;
using Application.Persistence;
using Domain.Models.ProfileModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using Domain.Exceptions;

namespace Application.Common.AppProfile;

public class CurrentLoggedProfile : ICurrentLoggedProfile
{
    #region DI
    private readonly ILogger<CurrentLoggedProfile> _logger;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUnitOfWork _unitOfWork;
    #endregion

    public Guid UUID { get; private set; }
    public string Email { get; private set; }
    public ProfileType Type { get; private set; }

    public CurrentLoggedProfile(ILogger<CurrentLoggedProfile> logger, IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _httpContextAccessor = httpContextAccessor;
        _unitOfWork = unitOfWork;

        LoadProfileInfo().GetAwaiter().GetResult();
    }

    public async Task LoadProfileInfo()
    {
        Claim? profileUuidClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier);
        if (!Guid.TryParse(profileUuidClaim?.Value, out Guid profileUuid))
            return;

        IProfileRepository profileRepository = _unitOfWork.GetRepository<Profile, IProfileRepository>();
        Profile currentProfile = await profileRepository.GetByUUIDAsync(profileUuid)
            ?? throw new AuthenticationException("Incorrect authentication token.", $"Profile with UUID {profileUuid} does not exists.");

        UUID = currentProfile.UUID;
        Email = currentProfile.Email;
        Type = currentProfile.Type;
    }
}
