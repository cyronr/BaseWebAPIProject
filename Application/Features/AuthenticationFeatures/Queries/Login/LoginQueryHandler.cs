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
    IJwtTokenService _jwtTokenService) : IRequestHandler<LoginQuery, AuthenticationResult>
{
    #region DI
    private readonly ILogger<LoginQueryHandler> _logger = _logger;
    private readonly IUnitOfWork _unitOfWork = _unitOfWork;
    private readonly IPasswordService _passwordService = _passwordService;
    private readonly IJwtTokenService _jwtTokenService = _jwtTokenService;
    #endregion

    public async Task<AuthenticationResult> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        _logger.LogDebug($"Logging profile ${query.Email}.");

        IProfileRepository profileRepository = _unitOfWork.GetRepository<Profile, IProfileRepository>();

        Profile? profile = await profileRepository.GetByEmailAsync(query.Email);
        if (profile is null)
            throw new AuthenticationException("Error during authentication.", $"Profile with address {query.Email} not exists.");

        if (!_passwordService.VerifyPassword(query.Password, profile.PasswordHash, profile.PasswordSalt))
            throw new AuthenticationException("Error during authentication.", "Wrong password.");

        return new AuthenticationResult(profile.Adapt<ProfileDto>(), _jwtTokenService.GenerateToken(profile));
    }
}
