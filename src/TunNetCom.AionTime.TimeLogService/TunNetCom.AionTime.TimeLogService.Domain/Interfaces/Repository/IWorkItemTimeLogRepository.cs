using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TunNetCom.AionTime.TimeLogService.Domain.Models;

namespace TunNetCom.AionTime.TimeLogService.Domain.Interfaces.Repository
{
    public interface IWorkItemTimeLogRepository:IGeniricRepository<WorkItemTimeLog>
    {
        Task<WorkItemTimeLog> GetWorkItemTimeLogWithDetails(int id);
        Task<List<WorkItemTimeLog>> GetWorkItemTimeLogWithDetails();
        Task<List<WorkItemTimeLog>> GetWorkItemTimeLogWithDetails(string userId);
        Task<bool> WorkItemTimeLogExists(string userId, int Id, int period);
        Task AddWorkItemTimeLog(List<WorkItemTimeLog> allocations);
        Task<WorkItemTimeLog> GetWorkItemTimeLogs(string userId, int Id);
    }
}
