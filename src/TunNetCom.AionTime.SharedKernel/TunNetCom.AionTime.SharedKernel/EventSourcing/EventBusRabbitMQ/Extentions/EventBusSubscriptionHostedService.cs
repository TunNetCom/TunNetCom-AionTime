namespace TunNetCom.AionTime.SharedKernel.EventSourcing.EventBusRabbitMQ.Extentions;

public class EventBusSubscriptionHostedService : IHostedService
{
    public Task StartAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
