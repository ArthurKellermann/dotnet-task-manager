namespace TaskManager.Domain.Common.CustomExceptions;
public class UserRegistrationException : Exception
{
    public UserRegistrationException(string message) : base(message)
    {
    }

    public UserRegistrationException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
