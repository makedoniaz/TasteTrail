#pragma warning disable CS8618
using MenuModel = TasteTrailApp.Core.Menu.Models.Menu;

namespace TasteTrailApp.Core.MenuItem.Models;

public class MenuItem
{
     public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public float Price { get; set; }
        public int PopularityRate { get; set; }
        public int? MenuId { get; set; }
        public MenuModel Menu { get; set; }
}
