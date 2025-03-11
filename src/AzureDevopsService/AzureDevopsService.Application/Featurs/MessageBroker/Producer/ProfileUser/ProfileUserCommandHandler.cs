using AzureDevopsService.Contracts.ExternalResponseModel;

namespace AzureDevopsService.Application.Featurs.MessageBroker.Producer.ProfileUser;

public class ProfileUserCommandHandler(
    IUserProfileApiClient userProfileApiClient,
    IPublishEndpoint publishEndpoint) :
    IRequestHandler<ProfileUserCommand>
{
    private readonly IUserProfileApiClient _userProfileApiClient = userProfileApiClient;
    private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;

    public async Task Handle(ProfileUserCommand request, CancellationToken cancellationToken)
    {
        OneOf<UserProfile, CustomProblemDetailsResponce> adminInfoResponse =
            await _userProfileApiClient.GetAdminInfo(request.Request.Path);
        if (adminInfoResponse.IsT0)
        {
            OneOf<UserAccountOrganization, CustomProblemDetailsResponce> organizationResponce =
                await _userProfileApiClient.GeUserOrganizations(adminInfoResponse.AsT0.Id, request.Request.Path);

            await _publishEndpoint.Publish(
                new GetAzureAdminInfoResponse
                {
                    Email = request.Request.Email,
                    UserProfile = adminInfoResponse!.AsT0,
                    TenantId = request.Request.TenantId,
                    Path = request.Request.Path,
                    UserOrganization = organizationResponce!.AsT0,
                },
                context =>
                {
                    context.SetRoutingKey("user.profile.routing.key");
                });
        }
        else
        {
            await _publishEndpoint.Publish(adminInfoResponse.AsT1);
        }
    }
}