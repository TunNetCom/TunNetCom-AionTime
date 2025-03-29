using WorkItemRequest = AzureDevopsService.Contracts.AzureRequestResourceModel.WorkItemRequest;

namespace TimeLogService.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TimeLogServiceController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost]
    [Route("CreateOrganization")]
    public async Task<IActionResult> CreateOrganization(OrganizationRequest organization)
    {
        return Ok(await _mediator.Send(new AddOrganizationCommand(organization)));
    }

    [HttpPost]
    [Route("ProfileUser")]
    public async Task<IActionResult> CreateOrganization(BaseRequest BaseRequest)
    {
        await _mediator.Send(new ProfileUserCommand(BaseRequest));
        return Ok();
    }

    [HttpPost]
    [Route("Project")]
    public async Task<IActionResult> CreateOrganization(GetOrganizationProjectsRequest request)
    {
        await _mediator.Send(new ProjectCommand(request));
        return Ok();
    }

    [HttpPost]
    [Route("WorkItem")]
    public async Task<IActionResult> CreateOrganization(WorkItemRequest BaseRequest)
    {
        await _mediator.Send(new WorkItemCommend(BaseRequest));
        return Ok();
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