using Moq;
using TasteTrailApp.Core.Models;
using TasteTrailApp.Core.Repositories;
using TasteTrailApp.Infrastructure.Services;

namespace UnitTests.Services;

public class MenuServiceTests
{
    private readonly Mock<IMenuRepository> menuRepositoryMock = new();

    [Fact]
    public async Task CreateAsync_CreationComplete_DoesntThrowException()
    {
        var menu = new Menu();

        menuRepositoryMock.Setup((repo) => repo.CreateAsync(menu))
                .ReturnsAsync(1);
        var menuService = new MenuSerivce(menuRepository: menuRepositoryMock.Object);

        await menuService.CreateAsync(menu);
    }

    [Fact]
    public async Task CreateAsync_CreationFailed_ThrowsInvalidOperationException()
    {
        var menu = new Menu();

        menuRepositoryMock.Setup((repo) => repo.CreateAsync(menu))
                .ReturnsAsync(0);
        var menuService = new MenuSerivce(menuRepository: menuRepositoryMock.Object);

        await Assert.ThrowsAsync<InvalidOperationException>(async () => await menuService.CreateAsync(menu));
    }

    [Fact]
    public async Task DeleteByIdAsync_DeleteComplete_DoesntThrowException()
    {
        var correctId = 0;

        menuRepositoryMock.Setup((repo) => repo.DeleteByIdAsync(correctId))
                .ReturnsAsync(1);
        var menuService = new MenuSerivce(menuRepository: menuRepositoryMock.Object);

        await menuService.DeleteByIdAsync(correctId);
    }

    [Fact]
    public async Task DeleteByIdAsync_DeleteFailed_ThrowsInvalidOperationException()
    {
        var wrongId = -10;

        menuRepositoryMock.Setup((repo) => repo.DeleteByIdAsync(wrongId))
                .ReturnsAsync(0);
        var menuService = new MenuSerivce(menuRepository: menuRepositoryMock.Object);

        await Assert.ThrowsAsync<InvalidOperationException>(async () => await menuService.DeleteByIdAsync(wrongId));
    }

    [Fact]
    public async Task PutAsync_PutComplete_DoesntThrowException()
    {
        var menu = new Menu();

        menuRepositoryMock.Setup((repo) => repo.PutAsync(menu))
                .ReturnsAsync(1);
        var menuService = new MenuSerivce(menuRepository: menuRepositoryMock.Object);

        await menuService.PutAsync(menu);
    }

    [Fact]
    public async Task PutAsync_PutFailed_ThrowsInvalidOperationException()
    {
        var menu = new Menu();

        menuRepositoryMock.Setup((repo) => repo.PutAsync(menu))
                .ReturnsAsync(0);
        var menuService = new MenuSerivce(menuRepository: menuRepositoryMock.Object);

        await Assert.ThrowsAsync<InvalidOperationException>(async () => await menuService.PutAsync(menu));
    }

    [Fact]
    public async Task GetByIdAsync_Found_DoesntThrowException() {
        var correctId = 0;
        var menu = new Menu();

        menuRepositoryMock.Setup((repo) => repo.GetByIdAsync(correctId))
                .ReturnsAsync(menu);
        var menuService = new MenuSerivce(menuRepository: menuRepositoryMock.Object);

        await menuService.GetByIdAsync(correctId);
    }

    [Fact]
    public async Task GetByIdAsync_NotFound_ThrowsArgumentNullException() {
        var wrongId = -10;

        menuRepositoryMock.Setup((repo) => repo.GetByIdAsync(wrongId))
                .ReturnsAsync(value: null);
        var menuService = new MenuSerivce(menuRepository: menuRepositoryMock.Object);

        await Assert.ThrowsAsync<ArgumentNullException>(async () => await menuService.GetByIdAsync(wrongId));
    }
}
