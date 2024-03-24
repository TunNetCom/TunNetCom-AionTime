namespace TunNetCom.AionTime.TimeLogService.Application.AutoMapping
{
    using AutoMapper;
    using TunNetCom.AionTime.TimeLogService.Contracts.DTOs.Request;
    using TunNetCom.AionTime.TimeLogService.Domain.Models;

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
