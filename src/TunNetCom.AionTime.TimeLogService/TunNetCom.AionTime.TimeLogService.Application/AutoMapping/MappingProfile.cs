namespace TunNetCom.AionTime.TimeLogService.Application.AutoMapping
{
    using AutoMapper;
    using TunNetCom.AionTime.TimeLogService.Contracts.DTOs.Request;
    using TunNetCom.AionTime.TimeLogService.Domain.Models;

    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            this.CreateMap<OrganizationRequest, Organisation>().ReverseMap();
            this.CreateMap<WorkItemRequest, WorkItem>();
            this.CreateMap<WorkItemHistoryRequest, WorkItemHistory>();
            this.CreateMap<WorkItemTimeLogRequest, WorkItemTimeLog>();
            this.CreateMap<ProjectRequest, Project>();
            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<OrganizationRequest, Organisation>().ReverseMap();
            //    cfg.CreateMap<WorkItemRequest, WorkItem>();
            //    cfg.CreateMap<WorkItemHistoryRequest, WorkItemHistory>();
            //    cfg.CreateMap<WorkItemTimeLogRequest, WorkItemTimeLog>();
            //    cfg.CreateMap<ProjectRequest, Project>();
            //});
            //var mapper = new Mapper(config);
            //return mapper;


        }
    }
}
