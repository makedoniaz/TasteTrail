using Moq;
using TasteTrailApp.Core.Models;
using TasteTrailApp.Core.Repositories;
using TasteTrailApp.Infrastructure.Services;

namespace UnitTests.Services;

public class MenuItemMenusServiceTests
{
        private readonly Mock<IMenuItemMenusRepository> menuItemMenusRepositoryMock = new();

    [Fact]
    public async Task CreateAsync_CreationComplete_DoesntThrowException()
    {
        var menuItemMenus = new MenuItemMenus();

        menuItemMenusRepositoryMock.Setup((repo) => repo.CreateAsync(menuItemMenus))
                .ReturnsAsync(1);
        var menuItemMenusService = new MenuItemMenusService(menuItemMenusRepository: menuItemMenusRepositoryMock.Object);

        await menuItemMenusService.CreateAsync(menuItemMenus);
    }

    [Fact]
    public async Task CreateAsync_CreationFailed_ThrowsInvalidOperationException()
    {
        var menuItemMenus = new MenuItemMenus();

        menuItemMenusRepositoryMock.Setup((repo) => repo.CreateAsync(menuItemMenus))
                .ReturnsAsync(0);
        var menuItemMenusService = new MenuItemMenusService(menuItemMenusRepository: menuItemMenusRepositoryMock.Object);

        await Assert.ThrowsAsync<InvalidOperationException>(async () => await menuItemMenusService.CreateAsync(menuItemMenus));
    }

    [Fact]
    public async Task DeleteByIdAsync_DeleteComplete_DoesntThrowException()
    {
        var correctId = 0;

        menuItemMenusRepositoryMock.Setup((repo) => repo.DeleteByIdAsync(correctId))
                .ReturnsAsync(1);
        var menuItemMenusService = new MenuItemMenusService(menuItemMenusRepository: menuItemMenusRepositoryMock.Object);

        await menuItemMenusService.DeleteByIdAsync(correctId);
    }

    [Fact]
    public async Task DeleteByIdAsync_DeleteFailed_ThrowsInvalidOperationException()
    {
        var wrongId = -10;

        menuItemMenusRepositoryMock.Setup((repo) => repo.DeleteByIdAsync(wrongId))
                .ReturnsAsync(0);
        var menuItemMenusService = new MenuItemMenusService(menuItemMenusRepository: menuItemMenusRepositoryMock.Object);

        await Assert.ThrowsAsync<InvalidOperationException>(async () => await menuItemMenusService.DeleteByIdAsync(wrongId));
    }

    [Fact]
    public async Task PutAsync_PutComplete_DoesntThrowException()
    {
        var menuItemMenus = new MenuItemMenus();

        menuItemMenusRepositoryMock.Setup((repo) => repo.PutAsync(menuItemMenus))
                .ReturnsAsync(1);
        var menuItemMenusService = new MenuItemMenusService(menuItemMenusRepository: menuItemMenusRepositoryMock.Object);

        await menuItemMenusService.PutAsync(menuItemMenus);
    }

    [Fact]
    public async Task PutAsync_PutFailed_ThrowsInvalidOperationException()
    {
        var menuItemMenus = new MenuItemMenus();

        menuItemMenusRepositoryMock.Setup((repo) => repo.PutAsync(menuItemMenus))
                .ReturnsAsync(0);
        var menuItemMenusService = new MenuItemMenusService(menuItemMenusRepository: menuItemMenusRepositoryMock.Object);

        await Assert.ThrowsAsync<InvalidOperationException>(async () => await menuItemMenusService.PutAsync(menuItemMenus));
    }
}
