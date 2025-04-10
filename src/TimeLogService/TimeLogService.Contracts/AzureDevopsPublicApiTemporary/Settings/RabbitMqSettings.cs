namespace TimeLogService.Contracts.AzureDevopsPublicApiTemporary.Settings;

public class RabbitMqSettings
{
    public required string ServiceName { get; set; }

    public required string UserName { get; set; }

    public required string Password { get; set; }
}