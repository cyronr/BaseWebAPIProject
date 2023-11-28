using Domain.Models.ProfileModels;

namespace Application.Common.AppProfile
{
    public class CallerProfile
    {
        private Profile profileEntity;

        public Guid Id { get; }
        public string Email { get; } = null!;
        public ProfileStatus Status { get; }
        public ProfileType Type { get; }
        public bool IsAdmin { get => this.Type == ProfileType.Admin ? true : false; }

        private CallerProfile(ICurrentLoggedProfile currentLoggedProfile)
        {
            var _currentLoggedProfile = currentLoggedProfile.GetCurrentLoggedProfile();

            if (_currentLoggedProfile is not null) 
            {
                this.Id = _currentLoggedProfile.UUID;
                this.Email = _currentLoggedProfile.Email;
                this.Status = _currentLoggedProfile.Status;
                this.Type = _currentLoggedProfile.Type;

                this.profileEntity = _currentLoggedProfile;
            }
        }

        public static CallerProfile GetCurrentLoggedProfile(ICurrentLoggedProfile currentLoggedProfile)
        {
            return new(currentLoggedProfile);
        }

        public Profile GetProfileEntity()
        {
            return this.profileEntity;
        }

    }
}
