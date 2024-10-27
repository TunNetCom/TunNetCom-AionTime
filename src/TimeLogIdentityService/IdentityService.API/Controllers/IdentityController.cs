#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace IdentityService.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IdentityController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost]
    [Route("CreateAccount")]
    public async Task<IActionResult> CreateAccount(CreateAccountCommand account)
    {
        IdentityResult user = await _mediator.Send(account);
        return Ok(user);
    }

    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login(LoginCommand login)
    {
        ApiResponse<LoginResponse> user = await _mediator.Send(login);
        return Ok(user);
    }

    [HttpPost]
    [Route("AddRole")]
    public async Task<IActionResult> AddRole(AddRoleCommand role)
    {
        IdentityResult roleResponse = await _mediator.Send(role);
        return Ok(roleResponse);
    }

    [HttpPost]
    [Route("AttachUserToRole")]
    public async Task<IActionResult> AttachUserToRole(AttachUserToRoleCommand userToRole)
    {
        ApiResponse<UserToRoleResponse> response = await _mediator.Send(userToRole);
        return Ok(response);
    }
}