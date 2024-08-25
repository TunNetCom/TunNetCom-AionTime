using AzureDevopsService.Contracts.AzureRequestResourceModel;
using TunNetCom;
using TunNetCom.AionTime;
using TunNetCom.AionTime.AzureDevopsService;
using TunNetCom.AionTime.AzureDevopsService.Contracts;
using TunNetCom.AionTime.AzureDevopsService.Contracts.AzureRequestResourceModel;

namespace AzureDevopsService.Contracts.AzureRequestResourceModel;

public class BaseRequest
{
    public string? Email { get; set; }

    public string? Path { get; set; }
}