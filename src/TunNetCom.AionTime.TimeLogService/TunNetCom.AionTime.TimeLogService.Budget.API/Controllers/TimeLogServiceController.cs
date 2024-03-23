namespace TunNetCom.AionTime.Budget.API.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using TunNetCom.AionTime.TimeLogService.Application.Feature.Organization.Commands;
    using TunNetCom.AionTime.TimeLogService.Application.Feature.Organization.Commands.DeletOrganization;
    using TunNetCom.AionTime.TimeLogService.Application.Feature.Organization.Commands.UpdateOrganization;
    using TunNetCom.AionTime.TimeLogService.Application.Feature.Organization.Queries.GetOrganization;
    using TunNetCom.AionTime.TimeLogService.Application.Feature.Organization.Queries.GetOrganizationById;
    using TunNetCom.AionTime.TimeLogService.Contracts.DTOs.Request;
    using TunNetCom.AionTime.TimeLogService.Domain.Models;

    [ApiController]
    [Route("[controller]")]
    public class TimeLogServiceController : ControllerBase
    {
        private readonly ILogger<WorkItemTimeLog> logger;
        private readonly IMediator mediator;

        public TimeLogServiceController(
            ILogger<WorkItemTimeLog> logger,
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
        public async Task<IActionResult> DeletOrganization(OrganizationRequest organization)
        {
            return this.Ok(await this.mediator.Send(new DeleteOrganizationCommand(organization)));
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
}
