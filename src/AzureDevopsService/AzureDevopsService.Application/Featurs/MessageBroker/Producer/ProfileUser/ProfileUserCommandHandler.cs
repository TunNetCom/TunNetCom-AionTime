namespace AzureDevopsService.Application.Featurs.MessageBroker.Producer.ProfileUser;

public class ProfileUserCommandHandler(IUserProfileApiClient userProfileApiClient, ISendEndpointProvider sendEndpointProvider) :
    IRequestHandler<ProfileUserCommand>
{
    private readonly IUserProfileApiClient _userProfileApiClient = userProfileApiClient;

    private readonly ISendEndpointProvider _sendEndpointProvider = sendEndpointProvider;

    public async Task Handle(ProfileUserCommand request, CancellationToken cancellationToken)
    {
        ISendEndpoint endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("rabbitmq://rabbitmq/ProfileUserResponce"));

        OneOf<UserProfile?, CustomProblemDetailsResponce?> adminInfoResponse = await _userProfileApiClient.GetAdminInfo(request.BaseRequest);
        if (adminInfoResponse.IsT0)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8601 // Possible null reference assignment.
            OneOf<UserAccount?, CustomProblemDetailsResponce?> organizationResponce = await _userProfileApiClient.GeUserOrganizations(
                new GetUserOrganizationRequest
                {
                    Email = adminInfoResponse.AsT0.Email,
                    MemberId = adminInfoResponse.AsT0.Id,
                    Path = adminInfoResponse.AsT0.Path,
                });
#pragma warning disable CS8634 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'class' constraint.
            await endpoint.Send(organizationResponce.AsT0, cancellationToken);
#pragma warning restore CS8634 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'class' constraint.

#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }
        else
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            await endpoint.Send(
                new CustomProblemDetailsResponce
                {
                    Detail = adminInfoResponse.AsT1.Detail,
                    Email = adminInfoResponse.AsT1.Email,
                    Path = adminInfoResponse.AsT1.Path,
                    Status = adminInfoResponse.AsT1.Status,
                },
                cancellationToken);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }
    }
}