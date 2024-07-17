#pragma warning disable CS8618

using TasteTrailApp.Core.Venues.Models;

namespace TasteTrailApp.Core.VenuesPhotos.Models;

public class VenuePhotos
{
    public int Id { get; set; }
    public int VenueId { get; set; }
    public string PhotoUrlPath { get; set; }
    public Venue Venue { get; set; }
}
