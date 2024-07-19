using MediatR;
using TasteTrailApp.Core.MenuItems.Commands;
using TasteTrailApp.Core.MenuItems.Models;
using TasteTrailApp.Core.MenuItems.Repositories;

namespace TasteTrailApp.Infrastructure.MenuItems.Handlers;

public class CreateHandler : IRequestHandler<CreateMenuItemCommand>
{
    private readonly IMenuItemRepository menuItemRepository;

    public CreateHandler(IMenuItemRepository menuItemRepository)
    {
        this.menuItemRepository = menuItemRepository;
    }

    public async Task Handle(CreateMenuItemCommand request, CancellationToken cancellationToken)
    {
        var newMenuItem = new MenuItem {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            PopularityRate = request.PopularityRate,
            MenuId = request.MenuId
        };

        var changesCount = await menuItemRepository.CreateAsync(newMenuItem);

        if (changesCount == 0)
            throw new InvalidOperationException($"{nameof(newMenuItem)} creation didn't apply!");
    }
}
