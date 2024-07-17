#pragma warning disable CS8618

using TasteTrailApp.Core.Venues.Models;

namespace TasteTrailApp.Core.Feedbacks.Models;

public class Feedback
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string? Text { get; set; }

    public int Rating { get; set; }

    public DateTime CreationDate { get; set; }

    public int VenueId { get; set; }
    
    public Venue Venue { get; set; }
}
