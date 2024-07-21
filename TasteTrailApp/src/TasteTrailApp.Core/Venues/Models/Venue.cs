#pragma warning disable CS8618

using TasteTrailApp.Core.Feedbacks.Models;
using TasteTrailApp.Core.Menus.Models;
using TasteTrailApp.Core.Users.Models;
using TasteTrailApp.Core.VenuesPhotos.Models;

namespace TasteTrailApp.Core.Venues.Models;

public class Venue
{
    public int Id { get; set; }
    
    public string Name { get; set; }

    public string Address { get; set; }

    public string Description { get; set; }

    public string ContactNumber { get; set; }

    public string Email { get; set; }

    public string? LogoUrlPath { get; set; }

    public float AveragePrice { get; set; }

    public float OverallRating { get; set; }

    public ICollection<Menu> Menus { get; set; }

    public ICollection<VenuePhotos> Photos { get; set; }

    public ICollection<Feedback> Feedbacks { get; set; }

    public string? UserId { get; set; }

    public User User { get; set; }
}
