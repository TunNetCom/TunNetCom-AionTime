namespace TunNetCom.AionTime.TimeLogService.Application.AutoMapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OrganizationRequest, Organization>().ReverseMap();
            CreateMap<WorkItemRequest, WorkItem>();
            CreateMap<WorkItemHistoryRequest, WorkItemHistory>();
            CreateMap<WorkItemTimeLogRequest, WorkItemTimeLog>();
            CreateMap<ProjectRequest, Project>();
        }
    }
}