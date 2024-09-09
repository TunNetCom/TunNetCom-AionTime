using MassTransit;
using MediatR;

namespace AzureDevopsService.Application.Featurs.MessageBroker.Producer.ProfileUser;

public class ProfileUserCommendHandler(IUserProfileApiClient userProfileApiClient, ISendEndpointProvider sendEndpointProvider) :
    IRequestHandler<ProfileUserCommend>
{
    private readonly IUserProfileApiClient _userProfileApiClient = userProfileApiClient;

    private readonly ISendEndpointProvider _sendEndpointProvider = sendEndpointProvider;

    public async Task Handle(ProfileUserCommend request, CancellationToken cancellationToken)
    {
        ISendEndpoint endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("rabbitmq://rabbitmq/ProfileUserResponce"));

        OneOf<UserProfile?, CustomProblemDetailsResponce?> result = await _userProfileApiClient.GetAdminInfo(request.BaseRequest);
        if (result.IsT0)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8601 // Possible null reference assignment.
            var res = await _userProfileApiClient.GeUserOrganizations(
                new GetUserOrganizationRequest
                {
                    Email = result.AsT0.Email,
                    MemberId = result.AsT0.Id,
                    Path = result.AsT0.Path,
                });
#pragma warning disable CS8634 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'class' constraint.
            await endpoint.Send(res.AsT0, cancellationToken);
#pragma warning restore CS8634 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'class' constraint.

#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }
        else
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8601 // Possible null reference assignment.
            await endpoint.Send(
                new CustomProblemDetailsResponce
                {
                    Detail = result.AsT1.Detail,
                    Email = result.AsT1.Email,
                    Path = result.AsT1.Path,
                    Status = result.AsT1.Status,
                },
                cancellationToken);
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }
    }
}