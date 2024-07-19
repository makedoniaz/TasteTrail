using MediatR;
using TasteTrailApp.Core.MenuItems.Models;

namespace TasteTrailApp.Core.MenuItems.Queries;

public class GetMenuItemByIdQuery : IRequest<MenuItem>
{
    public int Id { get; set; }
}
