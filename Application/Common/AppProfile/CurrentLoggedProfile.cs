using Domain.Models.ProfileModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace Application.Common.AppProfile
{
    public class CurrentLoggedProfile : ICurrentLoggedProfile
    {
        private readonly ILogger<CurrentLoggedProfile> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        

        public CurrentLoggedProfile(ILogger<CurrentLoggedProfile> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public Profile? GetCurrentLoggedProfile()
        {
            throw new NotImplementedException();
            /*_logger.LogInformation("Try getting logged user.");
            /*_logger.LogInformation("Try getting logged user.");
            /*_logger.LogInformation("Try getting logged user.");
            /*_logger.LogInformation("Try getting logged user.");
            var loggerUserUUID = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (loggerUserUUID is null)
                return null;

            return _profileRepository.GetByUUID(Guid.Parse(loggerUserUUID));*/
        }
    }
}
