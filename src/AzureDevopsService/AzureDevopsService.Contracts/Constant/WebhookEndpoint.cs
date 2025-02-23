using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureDevopsService.Contracts.Constant
{
    public static class WebhookEndpoint
    {
        public const string AzureWorkItemsEvents = "AzureWorkItemsEvents";

        public const string BuildAndReleaseEvents = "BuildAndReleaseEvents";

        public const string AzureCodeEvents = "AzureCodeEvents";
    }
}