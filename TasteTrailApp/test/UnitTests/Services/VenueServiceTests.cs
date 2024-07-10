using Moq;
using TasteTrailApp.Core.Models;
using TasteTrailApp.Core.Repositories;
using TasteTrailApp.Infrastructure.Services;

namespace UnitTests.Services;

public class VenueServiceTests
{
    private readonly Mock<IVenueRepository> venueRepositoryMock = new();

    [Fact]
    public async Task CreateAsync_CreationComplete_DoesntThrowException()
    {
        var venue = new Venue();

        venueRepositoryMock.Setup((repo) => repo.CreateAsync(venue))
                .ReturnsAsync(1);
        var venueService = new VenueService(venueRepository: venueRepositoryMock.Object);

        await venueService.CreateAsync(venue, null);
    }

    [Fact]
    public async Task CreateAsync_CreationFailed_ThrowsInvalidOperationException()
    {
        var venue = new Venue();

        venueRepositoryMock.Setup((repo) => repo.CreateAsync(venue))
                .ReturnsAsync(0);
        var venueService = new VenueService(venueRepository: venueRepositoryMock.Object);

        await Assert.ThrowsAsync<InvalidOperationException>(async () => await venueService.CreateAsync(venue, null));
    }

    [Fact]
    public async Task DeleteByIdAsync_DeleteComplete_DoesntThrowException()
    {
        var correctId = 0;

        venueRepositoryMock.Setup((repo) => repo.DeleteByIdAsync(correctId))
                .ReturnsAsync(1);
        var venueService = new VenueService(venueRepository: venueRepositoryMock.Object);

        await venueService.DeleteByIdAsync(correctId);
    }

    [Fact]
    public async Task DeleteByIdAsync_DeleteFailed_ThrowsInvalidOperationException()
    {
        var wrongId = -10;

        venueRepositoryMock.Setup((repo) => repo.DeleteByIdAsync(wrongId))
                .ReturnsAsync(0);
        var venueService = new VenueService(venueRepository: venueRepositoryMock.Object);

        await Assert.ThrowsAsync<InvalidOperationException>(async () => await venueService.DeleteByIdAsync(wrongId));
    }

    [Fact]
    public async Task PutAsync_PutComplete_DoesntThrowException()
    {
        var venue = new Venue();

        venueRepositoryMock.Setup((repo) => repo.PutAsync(venue))
                .ReturnsAsync(1);
        var venueService = new VenueService(venueRepository: venueRepositoryMock.Object);

        await venueService.PutAsync(venue);
    }

    [Fact]
    public async Task PutAsync_PutFailed_ThrowsInvalidOperationException()
    {
        var venue = new Venue();

        venueRepositoryMock.Setup((repo) => repo.PutAsync(venue))
                .ReturnsAsync(0);
        var venueService = new VenueService(venueRepository: venueRepositoryMock.Object);

        await Assert.ThrowsAsync<InvalidOperationException>(async () => await venueService.PutAsync(venue));
    }

    [Fact]
    public async Task GetByIdAsync_Found_DoesntThrowException() {
        var correctId = 0;
        var venue = new Venue();

        venueRepositoryMock.Setup((repo) => repo.GetByIdAsync(correctId))
                .ReturnsAsync(venue);
        var venueService = new VenueService(venueRepository: venueRepositoryMock.Object);

        await venueService.GetByIdAsync(correctId);
    }

    [Fact]
    public async Task GetByIdAsync_NotFound_ThrowsArgumentNullException() {
        var wrongId = -10;

        venueRepositoryMock.Setup((repo) => repo.GetByIdAsync(wrongId))
                .ReturnsAsync(value: null);
        var venueService = new VenueService(venueRepository: venueRepositoryMock.Object);

        await Assert.ThrowsAsync<ArgumentNullException>(async () => await venueService.GetByIdAsync(wrongId));
    }
}
