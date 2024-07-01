namespace TasteTrailApp.Core.Models;

public class MenuItem
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string? Description { get; set; }

    public float Price { get; set; }

    public int PopularityRate { get; set; }

    public int PhotoUrlPath { get; set; }
}
