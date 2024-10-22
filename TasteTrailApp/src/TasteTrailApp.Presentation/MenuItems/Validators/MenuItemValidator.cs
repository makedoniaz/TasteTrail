using FluentValidation;
using TasteTrailApp.Core.MenuItems.Models;

namespace TasteTrailApp.Presentation.MenuItems.Validators;
public class MenuItemValidator : AbstractValidator<MenuItem>
{
    public MenuItemValidator()
    {
        RuleFor(item => item.Name)
                 .NotEmpty().WithMessage("Name is required.");

        RuleFor(item => item.Description)
            .NotEmpty().WithMessage("Description is required.");

        RuleFor(item => item.Price)
            .NotEmpty().WithMessage("Price is required.")
            .GreaterThan(0).WithMessage("Price must be greater than zero.");

        RuleFor(item => item.PopularityRate)
            .NotEmpty().WithMessage("Popularity Rate is required.")
            .GreaterThanOrEqualTo(0).WithMessage("Popularity Rate must be 0 or greater.");

        RuleFor(item => item.MenuId)
            .NotEmpty().WithMessage("Menu Id is required.");
    }
}
