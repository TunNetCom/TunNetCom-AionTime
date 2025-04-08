using FluentResults;

namespace IdentityService.API;

public static class IdentityEndpoint
{
    public static void AddEndpoints(this IEndpointRouteBuilder app)
    {
        _ = app.MapPost("/CreateTenantAccount", async (IMediator _mediator, [FromBody] CreateTenantAccountCommand request) =>
        {
            Result<IdentityResult> userResponse = await _mediator.Send(request);
            if (userResponse.IsFailed)
            {
                return Results.BadRequest(new ProblemDetails()
                {
                    Status = 400,
                    Detail = string.Join(", ", userResponse.Errors.Select(x => x.Message).ToList()),
                });
            }

            return Results.Ok(userResponse.Value);
        });

        _ = app.MapPost("/Login", async (
            IMediator mediator,
            [FromBody] LoginCommand request,
            CancellationToken cancellationToken) =>
        {
            Result<LoginResponse> userResponse = await mediator.Send(request, cancellationToken);
            if (userResponse.IsFailed)
            {
                return Results.BadRequest(new ProblemDetails()
                {
                    Status = 400,
                    Detail = string.Join(", ", userResponse.Errors.Select(x => x.Message).ToList()),
                });
            }

            return Results.Ok(userResponse.Value);
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
            Result<IdentityResult> response = await _mediator.Send(request);
            if (response.IsFailed)
            {
                return Results.BadRequest(new ProblemDetails()
                {
                    Status = 400,
                    Detail = string.Join(", ", response.Errors.Select(x => x.Message).ToList()),
                });
            }

            return Results.Ok(response.Value);
        });

        _ = app.MapPost("/ChangePassword", async (IMediator _mediator, [FromBody] ChangePasswordCommand request) =>
        {
            Result<IdentityResult> response = await _mediator.Send(request);
            if (response.IsFailed)
            {
                return Results.BadRequest(new ProblemDetails()
                {
                    Status = 400,
                    Detail = string.Join(", ", response.Errors.Select(x => x.Message).ToList()),
                });
            }

            return Results.Ok(response.Value);
        });

        _ = app.MapPost("/GeneratePasswordResetToken", async (IMediator _mediator, [FromBody] GeneratePasswordResetTokenCommand request) =>
        {
            Result<string> response = await _mediator.Send(request);
            if (response.IsFailed)
            {
                return Results.BadRequest(new ProblemDetails()
                {
                    Status = 400,
                    Detail = string.Join(", ", response.Errors.Select(x => x.Message).ToList()),
                });
            }

            return Results.Ok(response.Value);
        });
    }
}