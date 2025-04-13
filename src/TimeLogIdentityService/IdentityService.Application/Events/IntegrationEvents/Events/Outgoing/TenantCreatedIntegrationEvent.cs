using TunNetCom.AionTime.SharedKernel.EventBus.Events;

namespace IdentityService.Application.Events.IntegrationEvents.Events.Outgoing;

public record class TenantCreatedIntegrationEvent(string Email, string Path, Guid TenantId) : IntegrationEvent;