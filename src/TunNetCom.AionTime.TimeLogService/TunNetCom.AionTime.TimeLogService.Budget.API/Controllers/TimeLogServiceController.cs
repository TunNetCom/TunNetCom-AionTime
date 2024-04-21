namespace TunNetCom.AionTime.Budget.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TimeLogServiceController : ControllerBase
{
    private readonly ILogger<TimeLogServiceController> logger;
    private readonly IMediator mediator;

    public TimeLogServiceController(
        ILogger<TimeLogServiceController> logger,
        IMediator mediator)
    {
        this.logger = logger;
        this.mediator = mediator;
    }

    [HttpPost]
    [Route("CreateOrganization")]
    public async Task<IActionResult> CreateOrganization(OrganizationRequest organization)
    {
        return this.Ok(await this.mediator.Send(new AddOrganizationCommand(organization)));
    }

    [HttpPost]
    [Route("UpdateOrganization")]
    public async Task<IActionResult> UpdateOrganization(OrganizationRequest organization)
    {
        return this.Ok(await this.mediator.Send(new UpdateOrganizationCommand(organization)));
    }

    [HttpPost]
    [Route("DeletOrganization")]
    public async Task<IActionResult> DeletOrganization(int id)
    {
        return this.Ok(await this.mediator.Send(new DeleteOrganizationCommand(id)));
    }

    [HttpGet]
    [Route("GetOrganizations")]
    public async Task<IActionResult> GetOrganizations()
    {
        return this.Ok(await this.mediator.Send(new GetOrganizationsQuery()));
    }

    [HttpGet]
    [Route("GetOrganization")]
    public async Task<IActionResult> GetOrganization(int id)
    {
        return this.Ok(await this.mediator.Send(new GetOrganizationByIdQuery(id)));
    }

}
