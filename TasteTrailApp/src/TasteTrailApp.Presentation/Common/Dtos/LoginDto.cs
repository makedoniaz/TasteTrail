#pragma warning disable CS8618
namespace TasteTrailApp.Presentation.Common.Dtos;
public class LoginDto
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string ReturnUrl { get; set; }
}
