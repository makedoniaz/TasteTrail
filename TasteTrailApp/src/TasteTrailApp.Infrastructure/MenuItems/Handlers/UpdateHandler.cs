using MediatR;
using TasteTrailApp.Core.MenuItems.Commands;
using TasteTrailApp.Core.MenuItems.Models;
using TasteTrailApp.Core.MenuItems.Repositories;

namespace TasteTrailApp.Infrastructure.MenuItems.Handlers;

public class UpdateHandler : IRequestHandler<UpdateMenuItemCommand>
{
    private readonly IMenuItemRepository menuItemRepository;

    public UpdateHandler(IMenuItemRepository menuItemRepository)
    {
        this.menuItemRepository = menuItemRepository;
    }

    public async Task Handle(UpdateMenuItemCommand request, CancellationToken cancellationToken)
    {
        var newMenuItem = new MenuItem {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            PopularityRate = request.PopularityRate,
        };

        var changesCount = await menuItemRepository.PutAsync(newMenuItem);

        if (changesCount == 0)
            throw new InvalidOperationException($"{nameof(newMenuItem)} update didn't apply!");
    }
}
