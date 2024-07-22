using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TasteTrailApp.Presentation.Common.ViewModels;

public class AdminDashboardViewModel
{
    public int TotalUsers { get; set; }
    public int TotalFeedbacks { get; set; }
    public int TotalVenues { get; set; }
}