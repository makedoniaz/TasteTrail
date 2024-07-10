using Moq;
using TasteTrailApp.Core.Repositories;

namespace UnitTests.Services;

public class VenueServiceTests
{
    private readonly Mock<IVenueRepository> courseRepositoryMock = new();

    [Fact]
    public async Task CreateVenueAsync_CreationComplete_DoesntThrowException()
    {

    }

    [Fact]
    public async Task CreateVenueAsync_CreationFailed_ThrowsInvalidOperationException()
    {

    }

    [Fact]
    public async Task DeleteVenueAsync_DeleteComplete_DoesntThrowException()
    {

    }
}
