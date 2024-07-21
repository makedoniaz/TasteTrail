using Microsoft.AspNetCore.Identity;

namespace TasteTrailApp.Core.Users.Models;

public class User : IdentityUser
{
    public bool IsBanned { get; set; }

    public bool IsMuted { get; set; }

    public string? AvatarPath { get; set; }
}
