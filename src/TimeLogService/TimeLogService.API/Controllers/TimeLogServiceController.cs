using TunNetCom.AionTime.TimeLogService.Application.Feature.OrganizationAction.Commands.AddOrganization;
using TunNetCom.AionTime.TimeLogService.Application.Feature.OrganizationAction.Commands.DeletOrganization;
using TunNetCom.AionTime.TimeLogService.Application.Feature.OrganizationAction.Commands.UpdateOrganization;
using TunNetCom.AionTime.TimeLogService.Application.Feature.OrganizationAction.Queries.GetOrganization;
using TunNetCom.AionTime.TimeLogService.Application.Feature.OrganizationAction.Queries.GetOrganizationById;

namespace TunNetCom.AionTime.TimeLogService.API.Controllers;

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