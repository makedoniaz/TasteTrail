#pragma warning disable CS8618
using MenuItemModel = TasteTrailApp.Core.MenuItem.Models.MenuItem;
using VenueModel = TasteTrailApp.Core.Venue.Models.Venue;

namespace TasteTrailApp.Core.Menu.Models;

public class Menu
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public int VenueId { get; set; }
    public VenueModel Venue { get; set; }
    public ICollection<MenuItemModel> MenuItems { get; set; }
}
