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
        private readonly IOrganisationRepository _organisationRepository;

        public TestController(ILogger<WorkItemTimeLog> logger , IWorkItemTimeLogRepository workItemTimeLogRepository, IOrganisationRepository organisationRepository)
        {
            _workItemTimeLogRepository = workItemTimeLogRepository;
            _logger = logger;
            _organisationRepository = organisationRepository;
        }

        [HttpPost()]
        [Route("CreateWorkItemTimeLog")]
        public async Task<ActionResult<List<WorkItemTimeLog>>> CreateWorkItemTimeLog(List<WorkItemTimeLog> workItemTimeLogs)
        {
             await _workItemTimeLogRepository.AddWorkItemTimeLog(workItemTimeLogs);
            return Ok();
        }

        [HttpPost()]
        [Route("CreateOrganisation")]
        public async Task<IActionResult> CreateOrganisation(Organisation organisation)
        {
            await _organisationRepository.CreateOrganisation(organisation);
            return Ok();
        }

        [HttpPost()]
        [Route("GetOrganisations")]
        public async Task<IActionResult> GetOrganisations()
        {
            return Ok(await _organisationRepository.GetOrganisations());
        }

        [HttpPost()]
        [Route("AddOrganisations")]
        public async Task<IActionResult> AddOrganisations(List<Organisation> organisations)
        {
            await _organisationRepository.AddOrganisations(organisations);
            return Ok();
        }
    }
}
