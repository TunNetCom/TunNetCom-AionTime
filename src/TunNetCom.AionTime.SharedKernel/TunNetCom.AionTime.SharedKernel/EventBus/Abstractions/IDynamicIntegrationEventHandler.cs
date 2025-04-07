using TunNetCom.AionTime.SharedKernel.EventBus.Abstractions;

namespace TunNetCom.AionTime.SharedKernel.EventBus.Abstractions;

public interface IDynamicIntegrationEventHandler
{
    Task Handle(dynamic eventData);
}