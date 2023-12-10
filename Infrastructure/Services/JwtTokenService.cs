using Application.Services;
using Domain.Models.ProfileModels;
using Infrastructure.Common.Classes;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Services;

public class JwtTokenService(ILogger<JwtTokenService> _logger, IOptions<JwtSettings> jwtOptions) : IJwtTokenService
{
    #region DI
    private readonly ILogger<JwtTokenService> _logger = _logger;
    private readonly IOptions<JwtSettings> _jwtOptions = jwtOptions;
    #endregion

    public string GenerateToken(Profile profile)
    {
        _logger.LogInformation($"Creating Jwt Token for {profile.Email}.");

        JwtSettings jwtSettings = _jwtOptions.Value;
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, profile.UUID.ToString()),
            new Claim(ClaimTypes.Name, profile.Email)
        };

        SigningCredentials signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key)),
            SecurityAlgorithms.HmacSha256Signature
        );

        var token = new JwtSecurityToken
        (
            issuer: jwtSettings.Issuer,
            claims: claims,
            expires: DateTime.Now.AddMinutes(jwtSettings.ExpiryMinutes),
            signingCredentials: signingCredentials
        );

        var strToken = new JwtSecurityTokenHandler().WriteToken(token);
        _logger.LogDebug($"Created login Jwt Token for {profile.Email} ({strToken}).");

        return strToken;
    }
}
