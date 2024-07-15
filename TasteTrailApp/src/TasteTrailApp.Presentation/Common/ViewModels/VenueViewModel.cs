using MenuModel = TasteTrailApp.Core.Menu.Models.Menu;
using VenueModel = TasteTrailApp.Core.Venue.Models.Venue;

namespace TasteTrailApp.Presentation.Common.ViewModels;

public class VenueViewModel
{
    public VenueModel? Venue { get; set; }
    public IEnumerable<MenuModel>? Menus { get; set; }
    
}
