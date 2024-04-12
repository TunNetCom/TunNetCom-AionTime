namespace TunNetCom.AionTime.TimeLogService.Application.AutoMapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            this.CreateMap<OrganizationRequest, Organization>().ReverseMap();
            this.CreateMap<WorkItemRequest, WorkItem>();
            this.CreateMap<WorkItemHistoryRequest, WorkItemHistory>();
            this.CreateMap<WorkItemTimeLogRequest, WorkItemTimeLog>();
            this.CreateMap<ProjectRequest, Project>();
        }
    }
}
