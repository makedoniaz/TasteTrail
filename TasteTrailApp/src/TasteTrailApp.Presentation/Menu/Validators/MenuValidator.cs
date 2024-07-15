using FluentValidation;
using MenuModel = TasteTrailApp.Core.Menu.Models.Menu;

namespace TasteTrailApp.Presentation.Menu.Validators;
public class MenuValidator : AbstractValidator<MenuModel>
{
    public MenuValidator()
    {
        RuleFor(menu => menu.Name)
              .NotEmpty().WithMessage("Name is required.");

        RuleFor(menu => menu.Description)
            .NotEmpty().WithMessage("Description is required.");

        RuleFor(menu => menu.VenueId)
            .NotEmpty().WithMessage("Venue Id is required.")
            .GreaterThan(0).WithMessage("Venue Id must be greater than zero.");
    }
}

