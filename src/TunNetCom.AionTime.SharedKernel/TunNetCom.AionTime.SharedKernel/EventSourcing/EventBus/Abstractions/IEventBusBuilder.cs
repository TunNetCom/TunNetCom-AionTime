namespace TunNetCom.AionTime.SharedKernel.EventBus.Abstractions;

public interface IEventBusBuilder
{
    IServiceCollection Services { get; }
}