using Microsoft.AspNetCore.Mvc;
using TasteTrailApp.Core.Services.Base;

namespace TasteTrailApp.Presentation.Controllers
{
    public class VenueController : Controller
    {
        private readonly IVenueService venueService;
        public VenueController(IVenueService venueService)
        {
            this.venueService = venueService;
        }

        public async Task<IActionResult> Index()
        {
            //Сейчас БД пустая. Будет ошибка ArgumentNullException. Мы ее в Сервисе выкидываем.
            var result = await venueService.GetByIdAsync(10);

            return base.View(model: result);
        }

        public IActionResult VenueCreation()
        {
            return View();
        }

    }
}
