namespace Application.Services;

public interface IPasswordService
{
    public void GeneratePassword(string password, out byte[] passwordHash, out byte[] passwordSalt);
    public bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt);
}
