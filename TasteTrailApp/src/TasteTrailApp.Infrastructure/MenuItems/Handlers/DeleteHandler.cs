using MediatR;
using TasteTrailApp.Core.MenuItems.Commands;
using TasteTrailApp.Core.MenuItems.Repositories;

namespace TasteTrailApp.Infrastructure.MenuItems.Handlers;

public class DeleteHandler : IRequestHandler<DeleteMenuItemCommand>
{
    private readonly IMenuItemRepository menuItemRepository;

    public DeleteHandler(IMenuItemRepository menuItemRepository)
    {
        this.menuItemRepository = menuItemRepository;
    }

    public async Task Handle(DeleteMenuItemCommand request, CancellationToken cancellationToken)
    {
        var id = request.Id;

        var changesCount = await menuItemRepository.DeleteByIdAsync(id);

        if (changesCount == 0)
            throw new InvalidOperationException($"id: {id} delete didn't apply!");
    }
}
