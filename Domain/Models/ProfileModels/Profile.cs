using System.Text.Json;

namespace Domain.Models.ProfileModels
{
    public class Profile
    {
        public int Id { get; set; }
        public Guid UUID { get; set; }
        public ProfileStatus.Status StatusId { get; set; }
        public ProfileStatus Status { get; set; }
        public ProfileType.Type TypeId { get; set; }
        public ProfileType Type { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public string? PhoneNumber { get; set; }
        public List<ProfileEvent> Events { get; set; }
        public List<ProfileEvent> CallerProfileEvents { get; set; }


        public override string ToString()
        {
            var profile = new
            {
                Id = UUID,
                Type = TypeId,
                PhoneNumber = PhoneNumber
            };

            return JsonSerializer.Serialize(profile);
        }

    }
}