namespace AzureDevopsService.Application.Featurs.MessageBroker.Producer.Webhook;

public record class CreateWebhookCommand(CreateWebhookRequest Request) : IRequest<WebhookCreatedResponse>;