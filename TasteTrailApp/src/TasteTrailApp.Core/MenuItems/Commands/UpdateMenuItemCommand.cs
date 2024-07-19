using MediatR;

namespace TasteTrailApp.Core.MenuItems.Commands;

public class UpdateMenuItemCommand : IRequest
{
    public required string Name { get; set; }

    public string? Description { get; set; }

    public float Price { get; set; }

    public int PopularityRate { get; set; }
}
