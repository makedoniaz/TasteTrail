using TasteTrailApp.Core.MenuItems.Models;
using TasteTrailApp.Core.Menus.Models;

namespace TasteTrailApp.Presentation.Common.ViewModels;

public class MenuViewModel
{
    public Menu? Menu { get; set; }
    
    public IEnumerable<MenuItem>? MenuItems { get; set; }
    
}
