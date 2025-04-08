namespace TunNetCom.AionTime.SharedKernel;

public class RabbitMQOptions
{
    public required string EventBusUserName { get; set; }

    public required string EventBusPassword { get; set; }

    public int EventBusRetryCount { get; set; } = 0;

    public required string ServiceName { get; set; }

    public string EventBusConnection { get; set; } = "localhost";
}