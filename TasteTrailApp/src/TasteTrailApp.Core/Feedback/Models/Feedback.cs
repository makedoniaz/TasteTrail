#pragma warning disable CS8618
using TasteTrailApp.Core.Venue.Models;
namespace TasteTrailApp.Core.Feedback.Models;

public class Feedback
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string? Text { get; set; }
    public int Rating { get; set; }
    public DateTime CreationDate { get; set; }
    public int VenueId { get; set; }
    public TasteTrailApp.Core.Venue.Models.Venue Venue { get; set; }
}
