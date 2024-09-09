using AzureDevopsService.Contracts.AzureRequestResourceModel;
using TimeLogService;
using TimeLogService.API;
using TimeLogService.API.Controllers;
using TimeLogService.Application.Feature.OrganizationAction.Commands.AddOrganization;
using TimeLogService.Application.Feature.OrganizationAction.Commands.DeletOrganization;
using TimeLogService.Application.Feature.OrganizationAction.Commands.UpdateOrganization;
using TimeLogService.Application.Feature.OrganizationAction.Queries.GetOrganization;
using TimeLogService.Application.Feature.OrganizationAction.Queries.GetOrganizationById;
using TimeLogService.Application.Feature.RabbitMqConsumer.Producer.ProfileUser;
using TimeLogService.Contracts.DTOs.Request;

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
        await _mediator.Send(new ProfileUserCommend(BaseRequest));
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