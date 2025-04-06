// using AzureDevopsService.Application.Featurs.CreateProjectsServicehooks;
// using Organization = AzureDevopsService.Contracts.SharedModel.Organization;

// namespace AzureDevopsService.Application.Featurs.Helper;

// public static class EventCreationHelper
// {
//    public static Collection<ServiceHookReques> PrepareAllWbhookEventRequest(CreateProjectsServicehooksCommand request)
//    {
//        Collection<ServiceHookReques> lisOfWebhokRequest = new()
//        {
//            PrepareWebhookRequest(request, ServiceHookEventType.WorkItem, WebhookEndpoint.AzureWorkItemsEvents),
//            PrepareWebhookRequest(request, ServiceHookEventType.Build, WebhookEndpoint.BuildAndReleaseEvents),
//            PrepareWebhookRequest(request, ServiceHookEventType.Release, WebhookEndpoint.BuildAndReleaseEvents),
//            PrepareWebhookRequest(request, ServiceHookEventType.Code, WebhookEndpoint.AzureCodeEvents),
//        };

// return lisOfWebhokRequest;
//    }

// private static Collection<ServiceHookReques> PrepareWebhookRequest(CreateProjectsServicehooksCommand request, IEnumerable<string> eventTypes, string endpoint)
//    {
//        Collection<ServiceHookReques> listServiceHookReques = new();
//        foreach (Organization organization in request.Organizations)
//        {
//            foreach (string projectId in organization.ProjectsIds)
//            {
//                foreach (string eventType in eventTypes)
//                {
//                    ServiceHookReques requestContent = new()
//                    {
//                        ConsumerActionId = WebhookSettings.ConsumerActionId,
//                        ConsumerId = WebhookSettings.ConsumerId,
//                        ConsumerInputs = new()
//                        {
//                            HttpHeaders = WebhookSettings.HttpHeaders,
//                            ResourceDetailsToSend = WebhookSettings.ResourceDetailsToSend,
//                            Url = string.Format(WebhookSettings.BaseUrl, endpoint, organization.OrganizationId, request.TenantId),
//                        },
//                        EventType = eventType,
//                        PublisherId = WebhookSettings.PublisherId,
//                        PublisherInputs = new()
//                        {
//                            ProjectId = projectId,
//                        },
//                    };

// listServiceHookReques.Add(requestContent);
//                }
//            }
//        }

// return listServiceHookReques;
//    }
// }