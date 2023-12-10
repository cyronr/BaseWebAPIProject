namespace Infrastructure.Common.Classes;

public class JwtSettings
{
    public string Issuer { get; init; } = null!;
    public int ExpiryMinutes { get; init; }
    public string Key { get; init; } = null!;
}
