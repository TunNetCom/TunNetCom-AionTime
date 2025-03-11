using WebhookService.Contracts.EventModels.SharedModels.EventModels;
using Organization = AzureDevopsService.Contracts.SharedModel.Organization;

namespace AzureDevopsService.Application.Featurs.MessageBroker.Producer.Helper;

public static class EventCreationHelper
{
    public static List<ServiceHookReques> PrepareAllWbhookEventRequest(CreateWebhookRequest request)
    {
        List<ServiceHookReques> lisOfWebhokRequest = [];

        lisOfWebhokRequest.AddRange(PrepareWorkItemWebhookRequest(request));
        lisOfWebhokRequest.AddRange(PrepareBuildWebhookRequest(request));
        lisOfWebhokRequest.AddRange(PrepareRelaiseWebhookRequest(request));
        lisOfWebhokRequest.AddRange(PrepareCodeWebhookRequest(request));

        return lisOfWebhokRequest;
    }

    public static List<ServiceHookReques> PrepareWorkItemWebhookRequest(CreateWebhookRequest request)
    {
        List<ServiceHookReques> listServiceHookReques = [];
        foreach (Organization organization in request.Organizations)
        {
            foreach (string projectId in organization.ProjectsIds)
            {
                foreach (string eventType in ServiceHookEventType.WorkItem)
                {
                    ServiceHookReques requestContent = new()
                    {
                        ConsumerActionId = WebhookSettings.ConsumerActionId,
                        ConsumerId = WebhookSettings.ConsumerId,
                        ConsumerInputs = new()
                        {
                            HttpHeaders = WebhookSettings.HttpHeaders,
                            ResourceDetailsToSend = WebhookSettings.ResourceDetailsToSend,
                            Url = string.Format(WebhookSettings.BaseUrl, WebhookEndpoint.AzureWorkItemsEvents, organization.OrganizationId, request.TenantId),
                        },
                        EventType = eventType,
                        PublisherId = WebhookSettings.PublisherId,
                        PublisherInputs = new()
                        {
                            ProjectId = projectId,
                        },
                    };

                    listServiceHookReques.Add(requestContent);
                }
            }
        }

        return listServiceHookReques;
    }

    public static List<ServiceHookReques> PrepareBuildWebhookRequest(CreateWebhookRequest request)
    {
        List<ServiceHookReques> listServiceHookReques = [];
        foreach (Organization organization in request.Organizations)
        {
            foreach (string projectId in organization.ProjectsIds)
            {
                foreach (string eventType in ServiceHookEventType.Build)
                {
                    ServiceHookReques requestContent = new()
                    {
                        ConsumerActionId = WebhookSettings.ConsumerActionId,
                        ConsumerId = WebhookSettings.ConsumerId,
                        ConsumerInputs = new()
                        {
                            HttpHeaders = WebhookSettings.HttpHeaders,
                            ResourceDetailsToSend = WebhookSettings.ResourceDetailsToSend,
                            Url = string.Format(WebhookSettings.BaseUrl, WebhookEndpoint.BuildAndReleaseEvents, organization.OrganizationId, request.TenantId),
                        },
                        EventType = eventType,
                        PublisherId = WebhookSettings.PublisherId,
                        PublisherInputs = new()
                        {
                            ProjectId = projectId,
                        },
                    };

                    listServiceHookReques.Add(requestContent);
                }
            }
        }

        return listServiceHookReques;
    }

    public static List<ServiceHookReques> PrepareRelaiseWebhookRequest(CreateWebhookRequest request)
    {
        List<ServiceHookReques> listServiceHookReques = [];
        foreach (Organization organization in request.Organizations)
        {
            foreach (string projectId in organization.ProjectsIds)
            {
                foreach (string eventType in ServiceHookEventType.Release)
                {
                    ServiceHookReques requestContent = new()
                    {
                        ConsumerActionId = WebhookSettings.ConsumerActionId,
                        ConsumerId = WebhookSettings.ConsumerId,
                        ConsumerInputs = new()
                        {
                            HttpHeaders = WebhookSettings.HttpHeaders,
                            ResourceDetailsToSend = WebhookSettings.ResourceDetailsToSend,
                            Url = string.Format(WebhookSettings.BaseUrl, WebhookEndpoint.BuildAndReleaseEvents, organization.OrganizationId, request.TenantId),
                        },
                        EventType = eventType,
                        PublisherId = WebhookSettings.PublisherId,
                        PublisherInputs = new()
                        {
                            ProjectId = projectId,
                        },
                    };

                    listServiceHookReques.Add(requestContent);
                }
            }
        }

        return listServiceHookReques;
    }

    public static List<ServiceHookReques> PrepareCodeWebhookRequest(CreateWebhookRequest request)
    {
        List<ServiceHookReques> listServiceHookReques = [];
        foreach (Organization organization in request.Organizations)
        {
            foreach (string projectId in organization.ProjectsIds)
            {
                foreach (string eventType in ServiceHookEventType.Code)
                {
                    ServiceHookReques requestContent = new()
                    {
                        ConsumerActionId = WebhookSettings.ConsumerActionId,
                        ConsumerId = WebhookSettings.ConsumerId,
                        ConsumerInputs = new()
                        {
                            HttpHeaders = WebhookSettings.HttpHeaders,
                            ResourceDetailsToSend = WebhookSettings.ResourceDetailsToSend,
                            Url = string.Format(WebhookSettings.BaseUrl, WebhookEndpoint.AzureCodeEvents, organization.OrganizationId, request.TenantId),
                        },
                        EventType = eventType,
                        PublisherId = WebhookSettings.PublisherId,
                        PublisherInputs = new()
                        {
                            ProjectId = projectId,
                        },
                    };

                    listServiceHookReques.Add(requestContent);
                }
            }
        }

        return listServiceHookReques;
    }
}