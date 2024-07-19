using MediatR;
using TasteTrailApp.Core.MenuItems.Models;
using TasteTrailApp.Core.MenuItems.Queries;
using TasteTrailApp.Core.MenuItems.Repositories;

namespace TasteTrailApp.Infrastructure.MenuItems.Handlers;

public class GetByCountHandler : IRequestHandler<GetMenuItemsByCountQuery, IEnumerable<MenuItem>>
{
    private readonly IMenuItemRepository menuItemRepository;

    public GetByCountHandler(IMenuItemRepository menuItemRepository)
    {
        this.menuItemRepository = menuItemRepository;
    }

    public async Task<IEnumerable<MenuItem>> Handle(GetMenuItemsByCountQuery request, CancellationToken cancellationToken)
    {
        var count = request.Count;

        return await menuItemRepository.GetByCountAsync(count);
    }
}
