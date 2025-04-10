using AzureDevopsService.Contracts.AzureResponceModel;
using TimeLogService.Contracts.AzureDevopsPublicApiTemporary.AzureResponceModel;
using Project = TimeLogService.Domain.Models.Dbo.Project;
using UserProfile = TimeLogService.Contracts.AzureDevopsPublicApiTemporary.AzureResponceModel.UserProfile;
using WorkItem = TimeLogService.Domain.Models.Dbo.WorkItem;
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