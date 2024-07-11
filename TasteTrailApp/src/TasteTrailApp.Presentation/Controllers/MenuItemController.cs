using Microsoft.AspNetCore.Mvc;
using TasteTrailApp.Core.Models;
using TasteTrailApp.Core.Services.Base;

namespace TasteTrailApp.Presentation.Controllers;

[Route("[controller]")]
public class MenuItemController : Controller
{
    // private readonly IValidator<Venue> _validator;
    private readonly IMenuItemService _menuItemService;

    public MenuItemController(IMenuItemService menuItemService) //IValidator<Venue> validator, 
    {
        // this._validator = validator;
        this._menuItemService = menuItemService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var menuItems = await this._menuItemService.GetByCountAsync(10);
        return base.View(model: menuItems);
    }

    [HttpGet]
    [Route("/[controller]/{menuItemId:int}")]
    public async Task<IActionResult> MenuItemInfo(int menuItemId)
    {
        try
        {
            var menuItem = await this._menuItemService.GetByIdAsync(id: menuItemId);
            return base.View(model: menuItem);
        }
        catch (System.Exception ex)
        {
            return base.StatusCode(statusCode: StatusCodes.Status500InternalServerError, value: ex.Message);
        }
    }

    [HttpGet]
    [Route("[action]/{menuId}", Name = "CreateMenuItemPage")]
    public IActionResult Create(int menuId)
    {
        TempData["MenuId"] = menuId;
        return base.View();
    }  

    [HttpPost(Name = "CreateMenuItemApi")]
    public async Task<IActionResult> Create(MenuItem newMenuItem)
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
            newMenuItem.MenuId = (int)TempData["MenuId"]!;
            await this._menuItemService.CreateAsync(entity: newMenuItem);
            return base.RedirectToAction(actionName: "Index");
        }
        catch (System.Exception ex)
        {
            return base.StatusCode(statusCode: StatusCodes.Status500InternalServerError, value: ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateDepartment([FromBody] MenuItem newMenuItem)
    {
        try
        {
            await this._menuItemService.PutAsync(entity: newMenuItem);
            return base.Ok();
        }
        catch (System.Exception ex)
        {
            return base.StatusCode(statusCode: StatusCodes.Status500InternalServerError, value: ex.Message);
        }
    }

    [HttpDelete("{menuItemId:int}")]
    public async Task<IActionResult> DeleteDepartment(int menuItemId)
    {
        try
        {
            await this._menuItemService.DeleteByIdAsync(id: menuItemId);
            return base.Ok();
        }
        catch (System.Exception ex)
        {
            return base.StatusCode(statusCode: StatusCodes.Status500InternalServerError, value: ex.Message);
        }
    }
}