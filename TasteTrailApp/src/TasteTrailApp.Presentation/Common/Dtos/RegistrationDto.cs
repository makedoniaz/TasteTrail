#pragma warning disable CS8618
namespace TasteTrailApp.Presentation.Common.Dtos;

public class RegistrationDto
{
    public string AvatarUrl { get; set; }
   public string FirstName { get; set; }
    public string LastName { get; set; } 
    public string Email { get; set; }
    public string Password { get; set; }
    // public DateTime DateOfBirth { get; set; }
    // public string Gender { get; set; }
    // public string Address { get; set; } 
    // public string PhoneNumber { get; set; } 
}