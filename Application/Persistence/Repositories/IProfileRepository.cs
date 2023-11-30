using Domain.Models.ProfileModels;

namespace Application.Persistence.Repositories;

public interface IProfileRepository : IRepository<Profile>
{
    Task<Profile?> GetByEmailAsync(string email);
}
