#pragma warning disable CS8618

using TasteTrailApp.Core.Users.Models;
using TasteTrailApp.Core.Venues.Models;

namespace TasteTrailApp.Core.Feedbacks.Models;

public class Feedback
{
    public int Id { get; set; }

    public string? Text { get; set; }

    public int Rating { get; set; }

    public DateTime CreationDate { get; set; }

    public string? UserId { get; set; }

    public User User { get; set; }

    public int VenueId { get; set; }
    
    public Venue Venue { get; set; }
}
