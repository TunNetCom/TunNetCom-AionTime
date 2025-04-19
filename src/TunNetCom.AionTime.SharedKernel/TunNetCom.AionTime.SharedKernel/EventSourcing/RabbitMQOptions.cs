namespace TunNetCom.AionTime.SharedKernel;

public class RabbitMQOptions
{
    public string EventBusConnection { get; set; } = "localhost";
    public string EventBusUserName { get; set; } = "guest";
    public string EventBusPassword { get; set; } = "guest";
    public string BrokerName { get; set; } = "aion_time_event_bus";
    public int EventBusRetryCount { get; set; } = 5;
    public string ExchangeType { get; set; } = "fanout"; 
    public string ServiceName { get; set; } = string.Empty;
}