using Microsoft.AspNetCore.Mvc;
using TasteTrailApp.Core.Models;
using TasteTrailApp.Core.Services.Base;
using TasteTrailApp.Presentation.ViewModels;

namespace TasteTrailApp.Presentation.Controllers;

[Route("[controller]")]
public class MenuController : Controller
{
    // private readonly IValidator<Venue> _validator;
    private readonly IMenuService _menuService;
    private readonly IMenuItemService _menuItemService;

    public MenuController(IMenuService menuService, IMenuItemService menuItemService) //IValidator<Venue> validator, 
    {
        // this._validator = validator;
        this._menuService = menuService;
        this._menuItemService = menuItemService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var menus = await this._menuService.GetAllAsync();
        return base.View(model: menus);
    }

    [HttpGet]
    [Route("[action]/{menuId:int}")]
    public async Task<IActionResult> MenuDetails(int menuId)
    {
         try
        {
            var viewmodel = new MenuViewModel()
            {
                Menu = await this._menuService.GetByIdAsync(id: menuId),
                MenuItems = await this._menuItemService.GetAllMenuItemsByMenuId(menuId)
            };

            return base.View(model: viewmodel);
        }
        catch (System.Exception ex)
        {
            return base.StatusCode(statusCode: StatusCodes.Status500InternalServerError, value: ex.Message);
        } 
    }

    [HttpGet]
    [Route("[action]/{venueId}", Name = "CreateMenuPage")]
    public IActionResult Create(int venueId)
    {
        TempData["VenueId"] = venueId;
        return base.View();
    }

    [HttpPost(Name = "CreateMenuApi")]
    [Route("[action]")]
    public async Task<IActionResult> Create(Menu newMenu)
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
            newMenu.VenueId = (int)TempData["VenueId"]!;
            await this._menuService.CreateAsync(entity: newMenu);
            return base.RedirectToRoute(routeName: "VenueDetails", new { venueId = (int)TempData["VenueId"]! });
        }
        catch (System.Exception ex)
        {
            return base.StatusCode(statusCode: StatusCodes.Status500InternalServerError, value: ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Menu newMenu)
    {
        try
        {
            await this._menuService.PutAsync(entity: newMenu);
            return base.Ok();
        }
        catch (System.Exception ex)
        {
            return base.StatusCode(statusCode: StatusCodes.Status500InternalServerError, value: ex.Message);
        }
    }

    [HttpDelete("{menuId:int}")]
    public async Task<IActionResult> Delete(int menuId)
    {
        try
        {
            await this._menuService.DeleteByIdAsync(id: menuId);
            return base.Ok();
        }
        catch (System.Exception ex)
        {
            return base.StatusCode(statusCode: StatusCodes.Status500InternalServerError, value: ex.Message);
        }
    }
}