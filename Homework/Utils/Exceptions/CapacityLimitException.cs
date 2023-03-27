namespace Utils.Exceptions;

public sealed class CapacityLimitException : Exception
{
    public CapacityLimitException(string message) : base(message)
    {
    }
}