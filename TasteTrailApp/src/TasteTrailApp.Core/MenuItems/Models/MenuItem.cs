#pragma warning disable CS8618

using TasteTrailApp.Core.Menus.Models;

namespace TasteTrailApp.Core.MenuItems.Models;

public class MenuItem
{
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public float Price { get; set; }

        public int PopularityRate { get; set; }

        public int? MenuId { get; set; }

        public Menu Menu { get; set; }
}
