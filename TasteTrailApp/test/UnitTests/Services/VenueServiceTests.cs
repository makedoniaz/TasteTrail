using Moq;
using TasteTrailApp.Core.Repositories;

namespace UnitTests.Services;

public class VenueServiceTests
{
    private readonly Mock<IVenueRepository> courseRepositoryMock = new();

    [Fact]
    public async Task CreateCourseAsync_CourseFound_DoesntThrowException()
    {

    }
}
