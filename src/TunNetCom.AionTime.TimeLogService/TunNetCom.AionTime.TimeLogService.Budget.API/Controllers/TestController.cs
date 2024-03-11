using Microsoft.AspNetCore.Mvc;
using TunNetCom.AionTime.TimeLogService.Domain.Interfaces.Repository;
using TunNetCom.AionTime.TimeLogService.Domain.Models;

namespace TunNetCom.AionTime.Budget.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<WorkItemTimeLog> _logger;
        private readonly IWorkItemTimeLogRepository  _workItemTimeLogRepository;
        private readonly IOrganisationRepository _organizationRepository;

        public TestController(ILogger<WorkItemTimeLog> logger , IWorkItemTimeLogRepository workItemTimeLogRepository, IOrganisationRepository organizationRepository)
        {
            _workItemTimeLogRepository = workItemTimeLogRepository;
            _logger = logger;
            _organizationRepository = organizationRepository;
        }

        [HttpPost()]
        [Route("CreateWorkItemTimeLog")]
        public async Task<ActionResult<List<WorkItemTimeLog>>> CreateWorkItemTimeLog(List<WorkItemTimeLog> workItemTimeLogs)
        {
             await _workItemTimeLogRepository.AddWorkItemTimeLog(workItemTimeLogs);
            return Ok();
        }

        [HttpPost()]
        [Route("CreateOrganization")]
        public async Task<IActionResult> CreateOrganization(Organisation organization)
        {
            await _organizationRepository.AddOrganization(organization);
            return Ok();
        }

        [HttpPost()]
        [Route("GetOrganizations")]
        public async Task<IActionResult> GetOrganizations()
        {
            return Ok(await _organizationRepository.GetOrganizations());
        }

        [HttpPost()]
        [Route("AddOrganizations")]
        public async Task<IActionResult> AddOrganizations(List<Organisation> organizations)
        {
            await _organizationRepository.AddOrganizations(organizations);
            return Ok();
        }
    }
}
