namespace TunNetCom.AionTime.AzureDevopsService.API.Clients.HttpHandlers.Exceptions;

public class PatNotFoundException : Exception
{
    public PatNotFoundException(string message)
        : base(message)
    {
    }

    public PatNotFoundException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public PatNotFoundException()
    {
    }
}