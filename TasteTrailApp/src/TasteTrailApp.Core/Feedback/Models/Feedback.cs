namespace TasteTrailApp.Core.Feedback.Models;

public class Feedback
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string? Text { get; set; }

    public int Rating { get; set; }

    public DateTime CreationDate { get; set; }
}
