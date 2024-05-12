namespace TunNetCom.AionTime.AzureDevopsService.API.Clients.HttpHandlers.Exceptions;

public class OrganizationNotProvidedException : Exception
{
    public OrganizationNotProvidedException(string message)
        : base(message)
    {
    }

    public OrganizationNotProvidedException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public OrganizationNotProvidedException()
    {
    }
}