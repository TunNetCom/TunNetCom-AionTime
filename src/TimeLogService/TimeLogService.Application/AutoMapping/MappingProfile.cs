using TimeLogService;
using TimeLogService.Application.AutoMapping;
using TimeLogService.Contracts.DTOs.Request;
using TimeLogService.Domain.Models.Dbo;

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
        }
    }
}