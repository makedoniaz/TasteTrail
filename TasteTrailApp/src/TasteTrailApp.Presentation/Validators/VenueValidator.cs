using System.Text.RegularExpressions;
using FluentValidation;
using TasteTrailApp.Core.Models;
namespace TasteTrailApp.Presentation.Validators;

public class VenueValidator : AbstractValidator<Venue>
{
    public VenueValidator()
    {
        RuleFor(venue => venue.Name)
               .NotEmpty().WithMessage("Name is required.");

        RuleFor(venue => venue.Address)
            .NotEmpty().WithMessage("Address is required.");

        RuleFor(venue => venue.Description)
            .NotEmpty().WithMessage("Description is required.");

        RuleFor(venue => venue.ContactNumber)
            .NotEmpty().WithMessage("Contact Number is required.")
            .WithMessage("Invalid Contact Number format.");
            //.Matches(new Regex(@"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$"))

        RuleFor(venue => venue.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid Email format.");

        RuleFor(venue => venue.AveragePrice)
            .NotEmpty().WithMessage("Average Price is required.")
            .GreaterThan(0).WithMessage("Average Price must be greater than zero.");

        RuleFor(venue => venue.OverallRating)
            .NotEmpty().WithMessage("Overall Rating is required.")
            .InclusiveBetween(0, 5).WithMessage("Overall Rating must be between 0 and 5.");

        RuleFor(venue => venue.Address)
            .NotEmpty().WithMessage("Address is required.");
    }
}

