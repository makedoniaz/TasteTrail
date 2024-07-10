using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TasteTrailApp.Core.Services.Base;
using TasteTrailApp.Core.Models;

namespace TasteTrailApp.Presentation.Controllers;

[Route("[controller]")]
public class VenueController : Controller
{
    // private readonly IValidator<Venue> _validator;
    private readonly IVenueService _venueService;

    public VenueController(IVenueService venueService) //IValidator<Venue> validator, 
    {
        // this._validator = validator;
        this._venueService = venueService;
    }

    [HttpGet] 
    public async Task<IActionResult> Index()
    {
        var venues = await this._venueService.GetByCountAsync(10);
        return base.View(model: venues);
    }

    // [HttpGet]
    // [Route("/[controller]/{venueId:Guid}")]
    // public async Task<IActionResult> VenuetInfo(Guid venueId)
    // {
    //     try
    //     {
    //         var venue = await this._venueService.GetVenueAsync(id: venueId);
    //         return base.View(model: venue);
    //     }
    //     catch (System.Exception ex)
    //     {
    //         return base.StatusCode(statusCode: StatusCodes.Status500InternalServerError, value: ex.Message);
    //     }
    // }

    [HttpGet]
    [Route("[action]", Name = "CreateVenuePage")]
    public IActionResult Create()
    {
        return base.View();
    }

    [HttpPost]
    [Route("/api/[controller]/[action]", Name = "CreateVenueApi")]
    public async Task<IActionResult> Create(Venue newVenue)
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
            
            await this._venueService.CreateAsync(entity: newVenue); 
            return base.RedirectToAction(actionName: "Index");
        }
        catch (System.Exception ex)
        {
            return base.StatusCode(statusCode: StatusCodes.Status500InternalServerError, value: ex.Message);
        }
    } 

    // [HttpPut]
    // public async Task<IActionResult> UpdateDepartment([FromBody] Venue venue)
    // {
    //     try
    //     {
    //         await this._venueService.UpdateVenueAsync(id: venue.Id, newVenue: venue);
    //         return base.Ok();
    //     }
    //     catch (System.Exception ex)
    //     {
    //         return base.StatusCode(statusCode: StatusCodes.Status500InternalServerError, value: ex.Message);
    //     }
    // }
 
    // [HttpDelete("{venueId:Guid}")]
    // public async Task<IActionResult> DeleteDepartment(Guid venueId)
    // {
    //     try
    //     {
    //         await this._venueService.DeleteVenueByIdAsync(id: venueId);
    //         return base.Ok();
    //     }
    //     catch (System.Exception ex)
    //     {
    //         return base.StatusCode(statusCode: StatusCodes.Status500InternalServerError, value: ex.Message);
    //     }
    // }
}

//  [HttpGet]
//     [Route("/[controller]")]
//     public async Task<IActionResult> Index()
//     {
//         var model = new MenuViewModel
//         { 
//             MenusItem = await this._menuItemService.GetAllMenuItemsAsync()
//             Menus = await this._menuService.GetAllMenusAsync()
//         };
//         return base.View(model);
//     }