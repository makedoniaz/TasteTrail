using TasteTrailApp.Core.Menus.Models;
using TasteTrailApp.Core.Venues.Models;

namespace TasteTrailApp.Presentation.Common.ViewModels;

public class VenueViewModel
{
    public Venue? Venue { get; set; }
    public IEnumerable<Menu>? Menus { get; set; }
    
}
