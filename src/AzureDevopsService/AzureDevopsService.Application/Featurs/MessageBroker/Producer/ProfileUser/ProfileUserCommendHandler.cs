using MediatR;

namespace AzureDevopsService.Application.Featurs.MessageBroker.Producer.ProfileUser;

public class ProfileUserCommendHandler(IUserProfileApiClient userProfileApiClient) :
    IRequestHandler<ProfileUserCommend, OneOf<UserAccount?, CustomProblemDetailsResponce?>>
{
    private readonly IUserProfileApiClient _userProfileApiClient = userProfileApiClient;

    public async Task<OneOf<UserAccount?, CustomProblemDetailsResponce?>> Handle(ProfileUserCommend request, CancellationToken cancellationToken)
    {
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
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            return res;
        }

#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8601 // Possible null reference assignment.
        return new CustomProblemDetailsResponce
        {
            Detail = result.AsT1.Detail,
            Email = result.AsT1.Email,
            Path = result.AsT1.Path,
            Status = result.AsT1.Status,
        };
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning restore CS8602 // Dereference of a possibly null reference.
    }
}