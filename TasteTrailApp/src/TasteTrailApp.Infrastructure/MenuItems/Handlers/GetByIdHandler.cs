using MediatR;
using TasteTrailApp.Core.MenuItems.Models;
using TasteTrailApp.Core.MenuItems.Queries;
using TasteTrailApp.Core.MenuItems.Repositories;

namespace TasteTrailApp.Infrastructure.MenuItems.Handlers;

public class GetByIdHandler : IRequestHandler<GetMenuItemByIdQuery, MenuItem>
{
    private readonly IMenuItemRepository menuItemRepository;

    public GetByIdHandler(IMenuItemRepository menuItemRepository)
    {
        this.menuItemRepository = menuItemRepository;
    }

    public async Task<MenuItem> Handle(GetMenuItemByIdQuery request, CancellationToken cancellationToken)
    {
        var id = request.Id;
        var menuItems = await menuItemRepository.GetByIdAsync(id);

        ArgumentNullException.ThrowIfNull(menuItems);

        return menuItems;
    }
}
