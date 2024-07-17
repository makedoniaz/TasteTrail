#pragma warning disable CS8618
using TasteTrailApp.Core.MenuItems.Models;
using TasteTrailApp.Core.Venues.Models;

namespace TasteTrailApp.Core.Menus.Models;

public class Menu
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string? Description { get; set; }

    public int VenueId { get; set; }

    public Venue Venue { get; set; }

    public ICollection<MenuItem> MenuItems { get; set; }
}
