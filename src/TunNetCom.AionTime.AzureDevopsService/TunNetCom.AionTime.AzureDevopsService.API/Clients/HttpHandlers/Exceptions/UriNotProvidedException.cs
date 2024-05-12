namespace TunNetCom.AionTime.AzureDevopsService.API.Clients.HttpHandlers.Exceptions;

public class UriNotProvidedException : Exception
{
    public UriNotProvidedException(string message)
        : base(message)
    {
    }

    public UriNotProvidedException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public UriNotProvidedException()
    {
    }
}