using Application.Persistence.Repositories;
using Domain.Models.ProfileModels;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Persistence.Repositories;

internal class ProfileRepository : GenericRepository<Profile>, IProfileRepository
{
    private readonly AppDbContext _appDbContext;
    private readonly ILogger<ProfileRepository> _logger;
    public ProfileRepository(AppDbContext appDbContext, ILogger<ProfileRepository> logger) : base(appDbContext, logger)
    {
        _appDbContext = appDbContext;
        _logger = logger;
    }

    public async Task<Profile?> GetByEmailAsync(string email)
    {
        return await _appDbContext.Profiles.FirstOrDefaultAsync(p => p.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
    }
}
