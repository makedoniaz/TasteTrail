using MediatR;
using TasteTrailApp.Core.MenuItems.Models;

namespace TasteTrailApp.Core.MenuItems.Queries;

public class GetMenuItemsByCountQuery : IRequest<IEnumerable<MenuItem>>
{
    public int Count { get; set; }
}
