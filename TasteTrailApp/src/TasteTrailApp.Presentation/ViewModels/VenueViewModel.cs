using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasteTrailApp.Core.Models;

namespace TasteTrailApp.Presentation.ViewModels;

public class VenueViewModel
{
    public Venue? Venue { get; set; }
    public IEnumerable<Menu>? Menus { get; set; }
    
}