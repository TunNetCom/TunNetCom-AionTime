
using OneOf;

namespace IdentityService.API;

public static class IdentityEndpoint
{
    public static void AddEndpoints(this IEndpointRouteBuilder app)
    {
        _ = app.MapPost("/CreateTenantAccount", async (IMediator _mediator, [FromBody] CreateTenantAccountCommand request) =>
        {
            OneOf<IdentityResult, ProblemDetails> userResponse = await _mediator.Send(request);
            if (userResponse.IsT1)
            {
                return Results.BadRequest(userResponse.AsT1);
            }

            if (userResponse.IsT0 && !userResponse.AsT0.Succeeded)
            {
                return Results.Ok(userResponse.AsT0);
            }

            return Results.Ok(userResponse.AsT0);
        });

        _ = app.MapPost("/Login", async (
            IMediator mediator,
            [FromBody] LoginCommand request,
            CancellationToken cancellationToken) =>
        {
            ApiResponse<LoginResponse> userResponse = await mediator.Send(request, cancellationToken);
            if (!userResponse.Succeeded)
            {
                return Results.BadRequest(userResponse);
            }

            return Results.Ok(userResponse);
        });

        _ = app.MapPost("/AddRole", async (IMediator _mediator, [FromBody] AddRoleCommand request) =>
        {
            IdentityResult roleResponse = await _mediator.Send(request);
            if (!roleResponse.Succeeded)
            {
                return Results.BadRequest(roleResponse);
            }

            return Results.Ok(roleResponse);
        });

        _ = app.MapPost("/AttachUserToRole", async (IMediator _mediator, [FromBody] AttachUserToRoleCommand request) =>
        {
            ApiResponse<UserToRoleResponse> response = await _mediator.Send(request);
            if (!response.Succeeded)
            {
                return Results.BadRequest(response);
            }

            return Results.Ok(response);
        });

        _ = app.MapPost("/ChangePassword", async (IMediator _mediator, [FromBody] ChangePasswordCommand request) =>
        {
            ApiResponse response = await _mediator.Send(request);
            if (!response.Succeeded)
            {
                return Results.BadRequest(response);
            }

            return Results.Ok(response);
        });

        _ = app.MapPost("/GeneratePasswordResetToken", async (IMediator _mediator, [FromBody] GeneratePasswordResetTokenCommand request) =>
        {
            ApiResponse<PasswordTokenResponse> response = await _mediator.Send(request);
            if (!response.Succeeded)
            {
                return Results.BadRequest(response);
            }

            return Results.Ok(response);
        });
    }
}