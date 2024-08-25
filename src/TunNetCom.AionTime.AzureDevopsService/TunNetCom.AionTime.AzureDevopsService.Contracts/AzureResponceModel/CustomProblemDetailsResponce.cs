using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TunNetCom.AionTime.AzureDevopsService.Contracts.AzureRequestResourceModel;

namespace TunNetCom.AionTime.AzureDevopsService.Contracts.AzureResponceModel
{
    public class CustomProblemDetailsResponce : ProblemDetails
    {
        public string? Email { get; set; }

        public string? Path { get; set; }
    }
}