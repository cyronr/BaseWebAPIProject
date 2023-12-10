using Application.Features.AuthenticationFeatures.Common;
using Application.Services;
using Domain.Exceptions;
using Domain.Models.ProfileModels;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.AuthenticationFeatures.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, AuthenticationResult>
{
    private readonly ILogger<LoginQueryHandler> _logger;
    private readonly IPasswordService _passwordHasher;
    private readonly IJwtTokenService _jwtTokenGenerator;

    public LoginQueryHandler(
        ILogger<LoginQueryHandler> logger,
        IPasswordService passwordHasher,
        IJwtTokenService jwtTokenGenerator)
    {
        _logger = logger;
        _passwordHasher = passwordHasher;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<AuthenticationResult> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        _logger.LogDebug($"Logging profile ${query.Email}.");

        _logger.LogDebug($"Fetching profile by email {query.Email}.");
        var profile = Profile.Create("", Domain.Models.ProfileModels.ProfileType.Admin);//await new Profile().GetByEmailAsync(_profileRepository, query.Email);

        if (!_passwordHasher.VerifyPassword(query.Password, profile.PasswordHash, profile.PasswordSalt))
            throw new WrongPasswordException("Wrong password.");

        var token = _jwtTokenGenerator.GenerateToken(profile);

        return new AuthenticationResult(/*_mapper.Map<ProfileDto>(profile)*/ null, token);
    }

}
