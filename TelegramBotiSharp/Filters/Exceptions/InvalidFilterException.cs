namespace TelegramBotiSharp.Filters.Exceptions;

[Serializable]
public class InvalidFilterException : Exception
{
    public InvalidFilterException()
    {
    }

    public InvalidFilterException(string? message) : base(message)
    {
    }

    public InvalidFilterException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}