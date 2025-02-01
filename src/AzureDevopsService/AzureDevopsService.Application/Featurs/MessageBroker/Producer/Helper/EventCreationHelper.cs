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
                        ConsumerActionId = "httpRequest",
                        ConsumerId = "webHooks",
                        ConsumerInputs = new()
                        {
                            HttpHeaders = "{\"Content-Type\": \"application/json\"}",
                            ResourceDetailsToSend = "all",
                            Url = $"https://your-public-api.com/AzureWorkItemsEvents?organizationId={organization.OrganizationId}",
                        },
                        EventType = eventType,
                        OrganizationName = organization.OrganizationName,
                        Path = request.Path,
                        PublisherId = "tfs",
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
                        ConsumerActionId = "httpRequest",
                        ConsumerId = "webHooks",
                        ConsumerInputs = new()
                        {
                            HttpHeaders = "{\"Content-Type\": \"application/json\"}",
                            ResourceDetailsToSend = "all",
                            Url = $"https://your-public-api.com/BuildAndReleaseEvents?organizationId={organization.OrganizationId}",
                        },
                        EventType = eventType,
                        OrganizationName = organization.OrganizationName,
                        Path = request.Path,
                        PublisherId = "tfs",
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
                        ConsumerActionId = "httpRequest",
                        ConsumerId = "webHooks",
                        ConsumerInputs = new()
                        {
                            HttpHeaders = "{\"Content-Type\": \"application/json\"}",
                            ResourceDetailsToSend = "all",
                            Url = $"https://your-public-api.com/BuildAndReleaseEvents?organizationId={organization.OrganizationId}",
                        },
                        EventType = eventType,
                        OrganizationName = organization.OrganizationName,
                        Path = request.Path,
                        PublisherId = "tfs",
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
                        ConsumerActionId = "httpRequest",
                        ConsumerId = "webHooks",
                        ConsumerInputs = new()
                        {
                            HttpHeaders = "{\"Content-Type\": \"application/json\"}",
                            ResourceDetailsToSend = "all",
                            Url = $"https://your-public-api.com/AzureCodeEvents?organizationId={organization.OrganizationId}",
                        },
                        EventType = eventType,
                        OrganizationName = organization.OrganizationName,
                        Path = request.Path,
                        PublisherId = "tfs",
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