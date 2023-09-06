using MediatR;

namespace Application.UnitTests.Mocks;

public static class MockMediator
{
    public static Mock<IMediator> GetMediator()
    {
        var mockMediator = new Mock<IMediator>();



        return mockMediator;
    }
}
