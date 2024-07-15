using MenuItemModel = TasteTrailApp.Core.MenuItem.Models.MenuItem;
using MenuModel = TasteTrailApp.Core.Menu.Models.Menu;

namespace TasteTrailApp.Presentation.Common.ViewModels;

public class MenuViewModel
{
    public MenuModel? Menu { get; set; }
    
    public IEnumerable<MenuItemModel>? MenuItems { get; set; }
    
}
