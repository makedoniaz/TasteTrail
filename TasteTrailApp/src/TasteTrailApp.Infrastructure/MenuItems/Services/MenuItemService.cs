﻿using TasteTrailApp.Core.MenuItems.Models;
using TasteTrailApp.Core.MenuItems.Repositories;
using TasteTrailApp.Core.MenuItems.Services;

namespace TasteTrailApp.Infrastructure.MenuItems.Services;

public class MenuItemService : IMenuItemService
{
    private readonly IMenuItemRepository menuItemRepository;

    public MenuItemService(IMenuItemRepository menuItemRepository)
    {
        this.menuItemRepository = menuItemRepository;
    }

    public async Task CreateAsync(MenuItem menuItem)
    {
        var changesCount = await this.menuItemRepository.CreateAsync(menuItem);

        if (changesCount == 0)
            throw new InvalidOperationException("MenuItem creation didn't apply!");
    }

    public async Task DeleteByIdAsync(int id)
    {
        var changesCount = await this.menuItemRepository.DeleteByIdAsync(id);

        if (changesCount == 0)
            throw new InvalidOperationException("MenuItem delete didn't apply!");
    }

    public async Task<IEnumerable<MenuItem>> GetAllMenuItemsByMenuId(int menuId)
    {
        var result = await this.menuItemRepository.GetAllByMenuId(menuId);
        return result;
    }

    public async Task<List<MenuItem>> GetByCountAsync(int count)
    {
        var result = await this.menuItemRepository.GetByCountAsync(count);
        return result;
    }

    public async Task<MenuItem> GetByIdAsync(int id)
    {
        var result = await this.menuItemRepository.GetByIdAsync(id);
        ArgumentNullException.ThrowIfNull(result);
        
        return result;
    }

    public async Task PutAsync(MenuItem menuItem)
    {
        var changesCount = await this.menuItemRepository.PutAsync(menuItem);

        if (changesCount == 0)
            throw new InvalidOperationException("MenuItem put didn't apply!");
    }
}

