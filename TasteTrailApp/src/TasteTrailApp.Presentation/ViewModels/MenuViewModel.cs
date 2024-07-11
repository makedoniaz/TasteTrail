using TasteTrailApp.Core.Models;

namespace TasteTrailApp.Presentation.ViewModels;

public class MenuViewModel
{
    public Menu? Menu { get; set; }
    public IEnumerable<MenuItem>? MenuItems { get; set; }
    
}
