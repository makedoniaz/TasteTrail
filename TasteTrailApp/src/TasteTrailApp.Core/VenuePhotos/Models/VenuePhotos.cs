#pragma warning disable CS8618
using VenueModel = TasteTrailApp.Core.Venue.Models.Venue;

namespace TasteTrailApp.Core.VenuePhotos.Models;

public class VenuePhotos
{
    public int Id { get; set; }
    public int VenueId { get; set; }
    public string PhotoUrlPath { get; set; }
    public VenueModel Venue { get; set; }
}
