namespace TunNetCom.AionTime.Budget.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TimeLogServiceController : ControllerBase
{
    private readonly ILogger<TimeLogServiceController> _logger;
    private readonly IMediator _mediator;

    public TimeLogServiceController(
        ILogger<TimeLogServiceController> logger,
        IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost]
    [Route("CreateOrganization")]
    public async Task<IActionResult> CreateOrganization(OrganizationRequest organization)
    {
        return Ok(await _mediator.Send(new AddOrganizationCommand(organization)));
    }

    [HttpPost]
    [Route("UpdateOrganization")]
    public async Task<IActionResult> UpdateOrganization(OrganizationRequest organization)
    {
        return Ok(await _mediator.Send(new UpdateOrganizationCommand(organization)));
    }

    [HttpPost]
    [Route("DeletOrganization")]
    public async Task<IActionResult> DeletOrganization(int id)
    {
        return Ok(await _mediator.Send(new DeleteOrganizationCommand(id)));
    }

    [HttpGet]
    [Route("GetOrganizations")]
    public async Task<IActionResult> GetOrganizations()
    {
        return Ok(await _mediator.Send(new GetOrganizationsQuery()));
    }

    [HttpGet]
    [Route("GetOrganization")]
    public async Task<IActionResult> GetOrganization(int id)
    {
        return Ok(await _mediator.Send(new GetOrganizationByIdQuery(id)));
    }
}
