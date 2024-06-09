namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels;

public class Message
{
    public string? Text { get; set; }

    public string? Html { get; set; }

    public string? Markdown { get; set; }
}