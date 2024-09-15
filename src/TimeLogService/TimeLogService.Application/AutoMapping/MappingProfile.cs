using TimeLogService;
using TimeLogService.Application.AutoMapping;
using TimeLogService.Contracts.DTOs.Request;
using TimeLogService.Domain.Models.Dbo;
using Project = TimeLogService.Domain.Models.Project;
using WorkItem = TimeLogService.Domain.Models.WorkItem;
using WorkItemRequest = TimeLogService.Contracts.DTOs.Request.WorkItemRequest;

namespace TimeLogService.Application.AutoMapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            _ = CreateMap<OrganizationRequest, Organization>().ReverseMap();
            _ = CreateMap<WorkItemRequest, WorkItem>();
            _ = CreateMap<WorkItemHistoryRequest, WorkItemHistory>();
            _ = CreateMap<WorkItemTimeLogRequest, WorkItemTimeLog>();
            _ = CreateMap<ProjectRequest, Project>();
            _ = CreateMap<UserProfile, User>();
        }
    }
}