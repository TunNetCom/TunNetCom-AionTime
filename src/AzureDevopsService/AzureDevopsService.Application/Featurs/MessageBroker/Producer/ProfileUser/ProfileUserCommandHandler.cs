namespace AzureDevopsService.Application.Featurs.MessageBroker.Producer.ProfileUser;

public class ProfileUserCommandHandler(
    IUserProfileApiClient userProfileApiClient,
    ISendEndpointProvider sendEndpointProvider,
    IPublishEndpoint publishEndpoint) :
    IRequestHandler<ProfileUserCommand>
{
    private readonly IUserProfileApiClient _userProfileApiClient = userProfileApiClient;
    private readonly ISendEndpointProvider _sendEndpointProvider = sendEndpointProvider;
    private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;

    public async Task Handle(ProfileUserCommand request, CancellationToken cancellationToken)
    {
        ISendEndpoint endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("rabbitmq://rabbitmq/ProfileUserResponce"));

        OneOf<UserProfile, CustomProblemDetailsResponce> adminInfoResponse = await _userProfileApiClient.GetAdminInfo(request.BaseRequest);
        if (adminInfoResponse.IsT0)
        {
            OneOf<UserAccount, CustomProblemDetailsResponce> organizationResponce = await _userProfileApiClient.GeUserOrganizations(
                new GetUserOrganizationRequest
                {
                    Email = adminInfoResponse.AsT0.Email,
                    MemberId = adminInfoResponse.AsT0.Id,
                    Path = adminInfoResponse.AsT0.Path,
                });

            adminInfoResponse.AsT0.UserAccount = organizationResponce.AsT0;

            // await endpoint.Send(adminInfoResponse.AsT0, cancellationToken);
            await _publishEndpoint.Publish(adminInfoResponse.AsT0);
        }
        else
        {
            //await endpoint.Send(
            //    new CustomProblemDetailsResponce
            //    {
            //        Detail = adminInfoResponse.AsT1.Detail,
            //        Email = adminInfoResponse.AsT1.Email,
            //        Path = adminInfoResponse.AsT1.Path,
            //        Status = adminInfoResponse.AsT1.Status,
            //    },
            //    cancellationToken);
        }
    }
}