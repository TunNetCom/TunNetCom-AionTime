using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureDevopsWebhookService.Contracts.Constant;

public static class WebhookEndPoint
{
    public const string AzureWorkItemsEvents = "AzureWorkItemsEvents";
    public const string AzureCodeEvents = "AzureCodeEvents";
    public const string AzurePipelineEvents = "AzurePipelineEvents";
    public const string BuildAndReleaseEvents = "BuildAndReleaseEvents";
}