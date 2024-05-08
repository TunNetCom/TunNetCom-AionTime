namespace TunNetCom.AionTime.TimeLogService.Application.AutoMapping
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