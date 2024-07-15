#pragma warning disable CS8618
using VenuePhotosModel = TasteTrailApp.Core.VenuePhotos.Models.VenuePhotos;
using FeedbackModel = TasteTrailApp.Core.Feedback.Models.Feedback;
using MenuModel = TasteTrailApp.Core.Menu.Models.Menu;

namespace TasteTrailApp.Core.Venue.Models;

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
    public ICollection<MenuModel> Menus { get; set; }
    public ICollection<VenuePhotosModel> Photos { get; set; }
    public ICollection<FeedbackModel> Feedbacks { get; set; }

    //public int OwnerId { get; set; }
}
