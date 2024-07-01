namespace TasteTrailApp.Core.Models;

public class User
{
    public int Id { get; set; }

    public string Login { get; set; }

    public string Password { get; set; }

    public string Email { get; set; }

    public string? AvatarUrlPath { get; set; }

    public bool IsActive { get; set; }

    public bool IsMuted { get; set; }
}
