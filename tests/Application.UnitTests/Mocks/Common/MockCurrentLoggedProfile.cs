namespace Application.UnitTests.Mocks.Common;
public static class MockCurrentLoggedProfile
{
    public static Mock<ICurrentLoggedProfile> GetAdminProfile(Guid? uuid = null)
    {
        Profile profile = new Profile
        {
            Id = 1,
            UUID = uuid is not null ? (Guid)uuid : Guid.NewGuid(),
            Status = ProfileStatus.Active,
            TypeId = ProfileType.Type.Admin,
            Type = new ProfileType
            {
                Id = ProfileType.Type.Admin,
                Name = "Admin"
            },
            Email = "mock@com",
        };

        var mockCurrentLoggedProfile = new Mock<ICurrentLoggedProfile>();

        mockCurrentLoggedProfile.Setup(r => r.GetCurrentLoggedProfile()).Returns(profile);

        return mockCurrentLoggedProfile;
    }
}
