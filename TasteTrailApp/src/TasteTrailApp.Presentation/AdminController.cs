using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TasteTrailApp.Presentation
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using TasteTrailApp.Presentation.Views.Admin;

    public class AdminController : Controller
    {


        public async Task<IActionResult> Dashboard()
        {
            var model = new AdminDashboardViewModel
            {
                TotalUsers = 0,
                TotalFeedbacks = 0,
                TotalVenues = 0
            };

            return View(model);
        }
    }

}