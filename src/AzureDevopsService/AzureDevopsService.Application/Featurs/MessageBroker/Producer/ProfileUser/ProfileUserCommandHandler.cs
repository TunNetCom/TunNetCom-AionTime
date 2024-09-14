namespace AzureDevopsService.Application.Featurs.MessageBroker.Producer.ProfileUser;

public class ProfileUserCommandHandler(IUserProfileApiClient userProfileApiClient, ISendEndpointProvider sendEndpointProvider) :
    IRequestHandler<ProfileUserCommand>
{
    private readonly IUserProfileApiClient _userProfileApiClient = userProfileApiClient;

    private readonly ISendEndpointProvider _sendEndpointProvider = sendEndpointProvider;

    public async Task Handle(ProfileUserCommand request, CancellationToken cancellationToken)
    {
        ISendEndpoint endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("rabbitmq://rabbitmq/ProfileUserResponce"));

        OneOf<UserProfile, CustomProblemDetailsResponce> adminInfoResponse = await _userProfileApiClient.GetAdminInfo(request.BaseRequest);
        if (adminInfoResponse.IsT0)
        {

            OneOf<UserAccount, CustomProblemDetailsResponce> organizationResponce = await _userProfileApiClient.GeUserOrganizations(
                new GetUserOrganizationRequest
                {
                    Email = adminInfoResponse!.AsT0!.Email,
                    MemberId = adminInfoResponse!.AsT0!.Id,
                    Path = adminInfoResponse!.AsT0!.Path,
                });

            await endpoint.Send(organizationResponce.AsT0, cancellationToken);
        }
        else
        {
            await endpoint.Send(
                new CustomProblemDetailsResponce
                {
                    Detail = adminInfoResponse!.AsT1!.Detail,
                    Email = adminInfoResponse!.AsT1!.Email,
                    Path = adminInfoResponse!.AsT1!.Path,
                    Status = adminInfoResponse!.AsT1!.Status,
                },
                cancellationToken);
        }
    }
}