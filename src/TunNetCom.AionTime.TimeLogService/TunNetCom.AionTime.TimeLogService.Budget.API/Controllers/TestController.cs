namespace TunNetCom.AionTime.Budget.API.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using TunNetCom.AionTime.TimeLogService.Domain.Models;

    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<WorkItemTimeLog> logger;
        private readonly IMediator mediator;

        public TestController(
            ILogger<WorkItemTimeLog> logger,
            IMediator mediator)
        {
            this.logger = logger;
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("CreateOrganization")]
        public async Task<IActionResult> CreateOrganization(Organisation organization)
        {
            return this.Ok(await this.mediator.Send(organization));
        }

    }
}
