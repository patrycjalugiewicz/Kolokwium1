namespace Kolokwium;

public class AlreadyExists :Exception
{
    public AlreadyExists()
    {
    }

    public AlreadyExists(string? message) : base(message)
    {
    }

    public AlreadyExists(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}