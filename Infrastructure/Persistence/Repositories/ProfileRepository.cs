using Application.Persistence.Repositories;
using Domain.Models.ProfileModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Persistence.Repositories;

internal class ProfileRepository : GenericRepository<Profile>, IProfileRepository
{
    #region DI
    private readonly AppDbContext _appDbContext;
    private readonly ILogger<ProfileRepository> _logger;
    #endregion
    public ProfileRepository(AppDbContext appDbContext, ILogger<ProfileRepository> logger) : base(appDbContext, logger)
    {
        _appDbContext = appDbContext;
        _logger = logger;
    }


    public async Task<Profile?> GetByEmailAsync(string email)
    {
        return await _appDbContext.Profiles.FirstOrDefaultAsync(p => p.Email.ToLower().Equals(email.ToLower()));
    }
    public async Task<Profile?> GetByEmailAsNoTrackingAsync(string email)
    {
        return await _appDbContext.Profiles.AsNoTracking().FirstOrDefaultAsync(p => p.Email.ToLower().Equals(email.ToLower()));
    }

    public async Task<ProfileEvent?> GetLastEventAsync(Profile profile, ProfileEventType profileEvent)
    {
        return await _appDbContext.ProfileEvents
            .Where(pe => pe.Profile == profile && pe.Type == profileEvent)
            .OrderBy(pe => pe.Timestamp)
            .LastOrDefaultAsync();
    }
}
