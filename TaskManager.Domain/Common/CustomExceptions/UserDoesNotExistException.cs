namespace TaskManager.Domain.Common.CustomExceptions;
public class UserDoesNotExistException : Exception
{
    public UserDoesNotExistException(string message) : base(message)
    {
    }

    public UserDoesNotExistException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
