using AzureDevopsService.Application.Events.IntegrationEvents.Events.Incoming;
using AzureDevopsService.Contracts.Internal.Interfaces;

namespace AzureDevopsService.API;

public static class AzureDevopsEndpoints
{
    public static void AddEndpoints(this IEndpointRouteBuilder app)
    {
        _ = app.MapPost("/GetAdminProfile", async (IUserProfileApiClient externalResourceService, [FromBody]
        TenantCreatedIntegrationEvent user) =>
        {
            OneOf<UserProfile, CustomProblemDetailsResponce> result = await externalResourceService.GetAdminInfo(user.Path);
            if (result.IsT1)
            {
                return Results.BadRequest(result.AsT1);
            }

            return Results.Ok(result.AsT0);
        });

        _ = app.MapPost("/{userId}/GetUserOrganization", async (string userId, string path, IUserProfileApiClient externalResourceService) =>
        {
            OneOf<UserAccountOrganization, CustomProblemDetailsResponce> result = await externalResourceService.GeUserOrganizations(userId, path);
            if (result.IsT1)
            {
                return Results.BadRequest(result.AsT1);
            }

            return Results.Ok(result.AsT0);
        });

        _ = app.MapPost("/wiql", async (IWorkItemExternalService workItemExternalService, WorkItemRequest workItemRequest) =>
        {
            OneOf<WiqlResponses, WiqlBadRequestResponce> result = await workItemExternalService.GetWorkItemByUser(workItemRequest);

            if (result.IsT1)
            {
                return Results.BadRequest(result.AsT1);
            }

            return Results.Ok(result.AsT0);
        });
    }
}