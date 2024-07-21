namespace TasteTrailApp.Core.Users.Exceptions;

public class UserNotFoundException : Exception
{
    public UserNotFoundException(string identifier)
        : base($"User: {identifier} not found.")
    {
    }
}
