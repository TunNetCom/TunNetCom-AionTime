using TunNetCom.AionTime.AzureDevopsService.Application.AzureDevopsExternalResourceService.ProjectService;
using TunNetCom.AionTime.AzureDevopsService.Contracts.AzureResponceModel;

namespace TunNetCom.AionTime.AzureDevopsService.API;

public static class Endpoints
{
    public static void AddEndpoints(this IEndpointRouteBuilder app)
    {
        _ = app.MapPost("/GetAdminProfile", async (IProfileUser externalResourceService, [FromBody] BaseRequest user) =>
        {
            OneOf<UserProfile?, CustomProblemDetailsResponce?> result = await externalResourceService.GetAdminInfo(user);
            if (result.IsT1)
            {
                return Results.BadRequest(result.AsT1);
            }

            return Results.Ok(result.AsT0);
        });

        _ = app.MapPost("/{userId}/GetUserOrganization", async (string userId, IProfileUser externalResourceService, [FromBody] GetUserOrganizationRequest request) =>
        {
            OneOf<UserAccount?, CustomProblemDetailsResponce?> result = await externalResourceService.GeUserOrganizations(request);
            if (result.IsT1)
            {
                return Results.BadRequest(result.AsT1);
            }

            return Results.Ok(result.AsT0);
        });

        _ = app.MapPost("/wiql", async (IWorkItemExternalService workItemExternalService, WorkItemRequest workItemRequest) =>
        {
            OneOf<WiqlResponses?, WiqlBadRequestResponce?> result = await workItemExternalService.GetWorkItemByUser(workItemRequest);

            if (result.IsT1)
            {
                return Results.BadRequest(result.AsT1);
            }

            return Results.Ok(result.AsT0);
        });

        _ = app.MapPost("/ProjectByOrganization", async (IProjectService workItemExternalService, AllProjectUnderOrganizationRequest request) =>
        {
            OneOf<AllProjectResponce?, CustomProblemDetailsResponce?> result = await workItemExternalService.AllProjectUnderOrganisation(request);

            if (result.IsT1)
            {
                return Results.BadRequest(result.AsT1);
            }

            return Results.Ok(result.AsT0);
        });
    }
}