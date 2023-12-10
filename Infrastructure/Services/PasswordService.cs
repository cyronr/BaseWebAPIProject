using Application.Services;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Services;

public class PasswordService(ILogger<PasswordService> _logger) : IPasswordService
{
    #region DI
    private readonly ILogger<PasswordService> _logger = _logger;
    #endregion

    public void GeneratePassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        _logger.LogInformation("Creating hash password.");

        using (var hmac = new System.Security.Cryptography.HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }

    public bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        _logger.LogInformation("Veryfing password with hash password.");

        using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
        {
            var computerHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computerHash.SequenceEqual(passwordHash);
        }
    }
}
