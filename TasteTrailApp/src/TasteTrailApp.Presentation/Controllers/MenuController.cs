using Microsoft.AspNetCore.Mvc;
using TasteTrailApp.Core.Models;
using TasteTrailApp.Core.Services.Base;

namespace TasteTrailApp.Presentation.Controllers;

[Route("[controller]")]
public class MenuController : Controller
{
    // private readonly IValidator<Venue> _validator;
    private readonly IMenuService _menuService;

    public MenuController(IMenuService menuService) //IValidator<Venue> validator, 
    {
        // this._validator = validator;
        this._menuService = menuService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var menus = await this._menuService.GetAllAsync();
        return base.View(model: menus);
    }

    [HttpGet]
    [Route("/[controller]/{menuId:int}")]
    public async Task<IActionResult> MenuInfo(int menuId)
    {
        try
        {
            var menu = await this._menuService.GetByIdAsync(id: menuId);
            return base.View(model: menu);
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
        return base.View(new Menu(){ VenueId = venueId});
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

            await this._menuService.CreateAsync(entity: newMenu);
            return base.RedirectToAction(actionName: "Index");
        }
        catch (System.Exception ex)
        {
            return base.StatusCode(statusCode: StatusCodes.Status500InternalServerError, value: ex.Message);
        }
    } 

    [HttpPut]
    public async Task<IActionResult> UpdateDepartment([FromBody] Menu newMenu)
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
    public async Task<IActionResult> DeleteDepartment(int menuId)
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