using Moq;
using TasteTrailApp.Core.MenuItems.Models;
using TasteTrailApp.Core.MenuItems.Repositories;
using TasteTrailApp.Infrastructure.MenuItems.Services;

namespace UnitTests.Services;

public class MenuItemServiceTests
{
    private readonly Mock<IMenuItemRepository> menuItemRepositoryMock = new();

    [Fact]
    public async Task CreateAsync_CreationComplete_DoesntThrowException()
    {
        var menuItem = new MenuItem();

        menuItemRepositoryMock.Setup((repo) => repo.CreateAsync(menuItem))
                .ReturnsAsync(1);
        var menuItemService = new MenuItemService(menuItemRepository: menuItemRepositoryMock.Object);

        await menuItemService.CreateAsync(menuItem);
    }

    [Fact]
    public async Task CreateAsync_CreationFailed_ThrowsInvalidOperationException()
    {
        var menuItem = new MenuItem();

        menuItemRepositoryMock.Setup((repo) => repo.CreateAsync(menuItem))
                .ReturnsAsync(0);
        var menuItemService = new MenuItemService(menuItemRepository: menuItemRepositoryMock.Object);

        await Assert.ThrowsAsync<InvalidOperationException>(async () => await menuItemService.CreateAsync(menuItem));
    }

    [Fact]
    public async Task DeleteByIdAsync_DeleteComplete_DoesntThrowException()
    {
        var correctId = 0;

        menuItemRepositoryMock.Setup((repo) => repo.DeleteByIdAsync(correctId))
                .ReturnsAsync(1);
        var menuItemService = new MenuItemService(menuItemRepository: menuItemRepositoryMock.Object);

        await menuItemService.DeleteByIdAsync(correctId);
    }

    [Fact]
    public async Task DeleteByIdAsync_DeleteFailed_ThrowsInvalidOperationException()
    {
        var wrongId = -10;

        menuItemRepositoryMock.Setup((repo) => repo.DeleteByIdAsync(wrongId))
                .ReturnsAsync(0);
        var menuItemService = new MenuItemService(menuItemRepository: menuItemRepositoryMock.Object);

        await Assert.ThrowsAsync<InvalidOperationException>(async () => await menuItemService.DeleteByIdAsync(wrongId));
    }

    [Fact]
    public async Task PutAsync_PutComplete_DoesntThrowException()
    {
        var menuItem = new MenuItem();

        menuItemRepositoryMock.Setup((repo) => repo.PutAsync(menuItem))
                .ReturnsAsync(1);
        var menuItemService = new MenuItemService(menuItemRepository: menuItemRepositoryMock.Object);

        await menuItemService.PutAsync(menuItem);
    }

    [Fact]
    public async Task PutAsync_PutFailed_ThrowsInvalidOperationException()
    {
        var menuItem = new MenuItem();

        menuItemRepositoryMock.Setup((repo) => repo.PutAsync(menuItem))
                .ReturnsAsync(0);
        var menuItemService = new MenuItemService(menuItemRepository: menuItemRepositoryMock.Object);

        await Assert.ThrowsAsync<InvalidOperationException>(async () => await menuItemService.PutAsync(menuItem));
    }

    [Fact]
    public async Task GetByIdAsync_Found_DoesntThrowException() {
        var correctId = 0;
        var menuItem = new MenuItem();

        menuItemRepositoryMock.Setup((repo) => repo.GetByIdAsync(correctId))
                .ReturnsAsync(menuItem);
        var menuItemService = new MenuItemService(menuItemRepository: menuItemRepositoryMock.Object);

        await menuItemService.GetByIdAsync(correctId);
    }

    [Fact]
    public async Task GetByIdAsync_NotFound_ThrowsArgumentNullException() {
        var wrongId = -10;

        menuItemRepositoryMock.Setup((repo) => repo.GetByIdAsync(wrongId))
                .ReturnsAsync(value: null);
        var menuItemService = new MenuItemService(menuItemRepository: menuItemRepositoryMock.Object);

        await Assert.ThrowsAsync<ArgumentNullException>(async () => await menuItemService.GetByIdAsync(wrongId));
    }
}
