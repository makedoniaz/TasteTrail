using FluentValidation;
using TasteTrailApp.Core.Menus.Models;

namespace TasteTrailApp.Presentation.Menus.Validators;

public class MenuValidator : AbstractValidator<Menu>
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

