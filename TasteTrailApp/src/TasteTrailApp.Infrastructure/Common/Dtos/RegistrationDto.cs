#pragma warning disable CS8618
namespace TasteTrailApp.Infrastructure.Common.Dtos;

public class RegistrationDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}