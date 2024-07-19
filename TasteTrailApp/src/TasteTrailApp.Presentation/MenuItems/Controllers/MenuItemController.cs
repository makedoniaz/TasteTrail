using MediatR;
using Microsoft.AspNetCore.Mvc;
using TasteTrailApp.Core.MenuItems.Commands;
using TasteTrailApp.Core.MenuItems.Queries;

namespace TasteTrailApp.Presentation.MenuItems.Controllers;

[Route("[controller]")]
public class MenuItemController : Controller
{
    // private readonly IValidator<Venue> _validator;

    private readonly ISender sender;

    public MenuItemController (ISender sender) //IValidator<Venue> validator, 
    {
        // this._validator = validator;
        this.sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var query = new GetMenuItemsByCountQuery() {
            Count = 10
        };

        var menuItems = await this.sender.Send(query);

        return base.View(model: menuItems);
    }

    [HttpGet]
    [Route("[action]/{menuItemId}")]
    public async Task<IActionResult> MenuItemDetails(int menuItemId)
    {
        try
        {
            var query = new GetMenuItemByIdQuery() {
                Id = menuItemId
            };

            var menuItem = await this.sender.Send(query);
            return base.View(model: menuItem);
        }
        catch (System.Exception ex)
        {
            return base.StatusCode(statusCode: StatusCodes.Status500InternalServerError, value: ex.Message);
        }
    }

    [HttpGet]
    [Route("Json/{menuItemId:int}")]
    public async Task<IActionResult> GetMenuItemJson(int menuItemId)
    {
        try
        {
            var query = new GetMenuItemByIdQuery() {
                Id = menuItemId
            };

            return base.Json(data: await this.sender.Send(query));
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
    public async Task<IActionResult> Create(CreateMenuItemCommand newMenuItem)
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

            await this.sender.Send(request: newMenuItem);
            return base.RedirectToRoute(routeName: "MenuDetails", new { menuId = (int)TempData["MenuId"]! });
        }
        catch (System.Exception ex)
        {
            return base.StatusCode(statusCode: StatusCodes.Status500InternalServerError, value: ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateMenuItemCommand newMenuItem)
    {
        try
        {
            await this.sender.Send(request: newMenuItem);
            return base.Ok();
        }
        catch (System.Exception ex)
        {
            return base.StatusCode(statusCode: StatusCodes.Status500InternalServerError, value: ex.Message);
        }
    }

    [HttpDelete("{menuItemId:int}")]
    public async Task<IActionResult> Delete(int menuItemId)
    {
        try
        {
            var query = new DeleteMenuItemCommand() {
                Id = menuItemId
            };

            await this.sender.Send(query);
            return base.Ok();
        }
        catch (System.Exception ex)
        {
            return base.StatusCode(statusCode: StatusCodes.Status500InternalServerError, value: ex.Message);
        }
    }
}