namespace Application.UnitTests.Mocks.DataAccess.Repositories;

public class MockProfileRepository
{
    public static Mock<IProfileRepository> GetProfileRepository()
    {
        var mockProfiles = PrepareListOfMockProfiles();

        return new Mock<IProfileRepository>().SetupRepository(mockProfiles);
    }

    public static List<Profile> PrepareListOfMockProfiles()
    {
        return new List<Profile>
        {
            new Profile
            {
                Id = 1,
                UUID = Guid.Parse(Consts.Active_Admin_Profile_UUID),
                StatusId = ProfileStatus.Active,
                Status = new ProfileStatus
                {
                    Id = ProfileStatus.Active,
                    Name = "Active"
                },
                TypeId = ProfileType.Type.Admin,
                Type = new ProfileType
                {
                    Id = ProfileType.Type.Admin,
                    Name = "Admin"
                },
                Email = "mock_admin@com",
                PhoneNumber = "123456789"
            },
            new Profile
            {
                Id = 2,
                UUID = Guid.NewGuid(),
                StatusId = ProfileStatus.Active,
                Status = new ProfileStatus
                {
                    Id = ProfileStatus.Active,
                    Name = "Active"
                },
                TypeId = ProfileType.Type.Doctor,
                Type = new ProfileType
                {
                    Id = ProfileType.Type.Doctor,
                    Name = "Doctor"
                },
                Email = "mock_doctor@com",
                PhoneNumber = "123456789"
            },
            new Profile
            {
                Id = 3,
                UUID = Guid.NewGuid(),
                StatusId = ProfileStatus.Active,
                Status = new ProfileStatus
                {
                    Id = ProfileStatus.Active,
                    Name = "Active"
                },
                TypeId = ProfileType.Type.Facility,
                Type = new ProfileType
                {
                    Id = ProfileType.Type.Facility,
                    Name = "Facility"
                },
                Email = "mock_facility@com",
                PhoneNumber = "123456789"
            },
            new Profile
            {
                Id = 4,
                UUID = Guid.NewGuid(),
                StatusId = ProfileStatus.Active,
                Status = new ProfileStatus
                {
                    Id = ProfileStatus.Active,
                    Name = "Active"
                },
                TypeId = ProfileType.Type.Patient,
                Type = new ProfileType
                {
                    Id = ProfileType.Type.Patient,
                    Name = "Patient"
                },
                Email = "mock_patient@com",
                PhoneNumber = "123456789"
            }
        };
    }
}

