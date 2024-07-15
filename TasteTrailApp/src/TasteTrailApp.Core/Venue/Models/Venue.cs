namespace TasteTrailApp.Core.Venue.Models;

public class Venue
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Address { get; set; }

    public string Description { get; set; }

    public string ContactNumber { get; set; }

    public string Email { get; set; }

    public string? LogoUrlPath  { get; set; }

    public float AveragePrice  { get; set; }

    public float OverallRating { get; set; }

    //public int OwnerId { get; set; }
}
