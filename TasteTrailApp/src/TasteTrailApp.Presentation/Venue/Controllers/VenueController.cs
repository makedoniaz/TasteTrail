using Microsoft.AspNetCore.Mvc;

using VenueModel = TasteTrailApp.Core.Venue.Models.Venue;
using FluentValidation;
using TasteTrailApp.Core.Menu.Services;
using TasteTrailApp.Core.Venue.Services;
using TasteTrailApp.Presentation.Common.ViewModels;

namespace TasteTrailApp.Presentation.Venue.Controllers;

[Route("[controller]")]
public class VenueController : Controller
{
    private readonly IValidator<VenueModel> _validator;

    private readonly IVenueService _venueService;

    private readonly IMenuService _menuService;

    public VenueController(IVenueService venueService, IMenuService menuService, IValidator<VenueModel> validator)
    {
        this._validator = validator;
        this._venueService = venueService;
        this._menuService = menuService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var venues = await this._venueService.GetByCountAsync(10);
        return base.View(model: venues);
    }

    [HttpGet]
    [Route("[action]/{venueId:int}", Name = "VenueDetails")]
    public async Task<IActionResult> VenueDetails(int venueId)
    {
        try
        {
            var viewmodel = new VenueViewModel()
            {
                Venue = await this._venueService.GetByIdAsync(id: venueId),
                Menus = await this._menuService.GetAllMenusByVenueId(venueId)
            };

            return base.View(model: viewmodel);
        }
        catch (System.Exception ex)
        {
            return base.StatusCode(statusCode: StatusCodes.Status500InternalServerError, value: ex.Message);
        }
    }

    [HttpGet]
    [Route("Json/{venueId:int}")]
    public async Task<IActionResult> GetVenueJson(int venueId)
    {
        try
        { 
            return base.Json(data: await this._venueService.GetByIdAsync(id: venueId));
        }
        catch (System.Exception ex)
        {
            return base.StatusCode(statusCode: StatusCodes.Status500InternalServerError, value: ex.Message);
        }
    }

    [HttpGet]
    [Route("[action]", Name = "CreateVenuePage")]
    public IActionResult Create()
    {
        return base.View();
    }

    [HttpPost]
    [Route("/api/[controller]/[action]", Name = "CreateVenueApi")]
    public async Task<IActionResult> Create([FromForm] VenueModel newVenue, IFormFile? logo)
    {
        try
        {
            // var validatorResult = this._validator.Validate(instance: newVenue);
            // if (!validatorResult.IsValid)
            // {
            //     foreach (var error in validatorResult.Errors)
            //     {
            //         base.ModelState.AddModelError(key: error.PropertyName, errorMessage: error.ErrorMessage);
            //     }

            //     return base.View(viewName: "Create");
            // }

            var createdId = await this._venueService.CreateAsyncRerturningId(venue: newVenue);
            var createdVenue = await this._venueService.GetByIdAsync(createdId);
            await this._venueService.SetVenueLogo(createdVenue, logo);

            return base.RedirectToAction(actionName: "Index");
        }
        catch (System.Exception ex)
        {
            return base.StatusCode(statusCode: StatusCodes.Status500InternalServerError, value: ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateVenue([FromBody] VenueModel venue)
    {
        try
        {
            await this._venueService.PutAsync(entity: venue);
            return base.Ok();
        }
        catch (System.Exception ex)
        {
            return base.StatusCode(statusCode: StatusCodes.Status500InternalServerError, value: ex.Message);
        }
    }

    [HttpDelete("{venueId:int}")]
    public async Task<IActionResult> DeleteVenue(int venueId)
    {
        try
        {
            await this._venueService.DeleteVenueLogoAsync(venueId);
            await this._venueService.DeleteByIdAsync(id: venueId);
            
            return base.Ok();
        }
        catch (System.Exception ex)
        {
            return base.StatusCode(statusCode: StatusCodes.Status500InternalServerError, value: ex.Message);
        }
    }

      
}
