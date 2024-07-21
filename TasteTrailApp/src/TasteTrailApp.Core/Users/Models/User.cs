#pragma warning disable CS8618

using Microsoft.AspNetCore.Identity;
using TasteTrailApp.Core.Feedbacks.Models;
using TasteTrailApp.Core.Venues.Models;

namespace TasteTrailApp.Core.Users.Models;

public class User : IdentityUser
{
    public bool IsBanned { get; set; }

    public bool IsMuted { get; set; }

    public string? AvatarPath { get; set; }

    public ICollection<Feedback> Feedbacks { get; set; }

    public ICollection<Venue> Venues { get; set; }
}
