using TasteTrailApp.Core.Feedbacks.Models;
using TasteTrailApp.Core.Menus.Models;
using TasteTrailApp.Core.Venues.Models;

namespace TasteTrailApp.Presentation.Common.ViewModels;

public class VenueViewModel
{
    public Venue? Venue { get; set; }
    
    public ICollection<Menu>? Menus { get; set; }
    public ICollection<Feedback>? Feedbacks { get; set; }
    
}

