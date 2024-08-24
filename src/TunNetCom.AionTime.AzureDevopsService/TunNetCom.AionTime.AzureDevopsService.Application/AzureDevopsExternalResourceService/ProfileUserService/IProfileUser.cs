using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Services.Organization.Client;
using Microsoft.VisualStudio.Services.Profile;
using Microsoft.VisualStudio.Services.Users;
using OneOf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TunNetCom;
using TunNetCom.AionTime;
using TunNetCom.AionTime.AzureDevopsService;
using TunNetCom.AionTime.AzureDevopsService.Application;
using TunNetCom.AionTime.AzureDevopsService.Application.AzureDevopsExternalResourceService;
using TunNetCom.AionTime.AzureDevopsService.Application.AzureDevopsExternalResourceService.ProfileUserService;
using TunNetCom.AionTime.AzureDevopsService.Contracts.AzureResponceModel;

namespace TunNetCom.AionTime.AzureDevopsService.Application.AzureDevopsExternalResourceService.ProfileUserService
{
    public interface IProfileUser
    {
        Task<OneOf<UserProfile?, CustomProblemDetailsResponce?>> GetAdminInfo(BaseRequest request);

        Task<OneOf<UserAccount?, CustomProblemDetailsResponce?>> GeUserOrganizations(GetUserOrganizationRequest request);
    }
}