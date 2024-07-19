using MediatR;

namespace TasteTrailApp.Core.MenuItems.Commands;

public class DeleteMenuItemCommand : IRequest
{
    public int Id { get; set; }
}
