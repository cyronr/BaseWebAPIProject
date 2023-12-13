using Application.Common;
using Application.Features.AuthenticationFeatures.Common;
using Application.Persistence;
using Application.Persistence.Repositories;
using Application.Services;
using Domain.Exceptions;
using Domain.Models.ProfileModels;
using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.AuthenticationFeatures.Queries.Login;

public class LoginQueryHandler(ILogger<LoginQueryHandler> _logger,
    IUnitOfWork _unitOfWork,
    IPasswordService _passwordService,
    IJwtTokenService _jwtTokenService,
    IDateTimeProvider _dateTimeProvider) : IRequestHandler<LoginQuery, AuthenticationResult>
{
    #region DI
    private readonly ILogger<LoginQueryHandler> _logger = _logger;
    private readonly IUnitOfWork _unitOfWork = _unitOfWork;
    private readonly IPasswordService _passwordService = _passwordService;
    private readonly IJwtTokenService _jwtTokenService = _jwtTokenService;
    private readonly IDateTimeProvider _dateTimeProvider = _dateTimeProvider;
    #endregion

    public async Task<AuthenticationResult> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        _logger.LogDebug($"Logging profile ${query.Email}.");
        IProfileRepository profileRepository = _unitOfWork.GetRepository<Profile, IProfileRepository>();

        Profile? profile = await profileRepository.GetByEmailAsync(query.Email);
        if (profile is null)
            throw new AuthenticationException("Error during authentication.", $"Profile with address {query.Email} not exists.");

        //TODO: Change to use Parameteres
        if (profile.UnsuccessfulLoginAttemptsCount >= 5)
        {
            DateTime? lastUnsuccessfulLoginAttempt = (await profileRepository.GetLastEventAsync(profile, ProfileEventType.UnsuccessfulLogonAttempt))?.Timestamp;

            //TODO: Change to use parameters 
            if (lastUnsuccessfulLoginAttempt is null || _dateTimeProvider.DateDiffrence(_dateTimeProvider.Now, lastUnsuccessfulLoginAttempt.Value).TotalSeconds > 1)
                await LogUnsuccessfulLogonAttempt(profile, "Too many unsuccessful login attempts.");

            throw new AuthenticationException("Error during authentication.", $"Too many unsuccessful login attempts for profile: {profile.ToString()}.");
        }

        if (!_passwordService.VerifyPassword(query.Password, profile.PasswordHash, profile.PasswordSalt))
        {
            await LogUnsuccessfulLogonAttempt(profile, "Wrong password.");
            throw new AuthenticationException("Error during authentication.", "Wrong password.");
        }

        string token = _jwtTokenService.GenerateToken(profile);
        await LogSuccessfulLogonAttempt(profile);
        return new AuthenticationResult(profile.Adapt<ProfileDto>(), token);
    }

    private async Task LogUnsuccessfulLogonAttempt(Profile profile, string message)
    {
        _logger.LogInformation($"Could not login profile {profile.ToString()} for reason: {message}.");

        profile.IncrementUnsuccessfulLoginAttemptsCount();
        profile.AddEvent(ProfileEventType.UnsuccessfulLogonAttempt, message);

        await _unitOfWork.SaveChangesAsync();
    }

    private async Task LogSuccessfulLogonAttempt(Profile profile)
    {
        profile.ResetUnsuccessfulLoginAttemptsCount();
        profile.AddEvent(ProfileEventType.SuccessfulLogon);

        await _unitOfWork.SaveChangesAsync();
    }
}
