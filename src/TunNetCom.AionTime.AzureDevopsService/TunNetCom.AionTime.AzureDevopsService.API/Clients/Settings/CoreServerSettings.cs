using System.ComponentModel.DataAnnotations;

namespace TunNetCom.AionTime.AzureDevopsService.API.Clients.Settings;

public class CoreServerSettings
{
    [Url]
    public required Uri DefaultUrl { get; set; }

    [Required]
    public required string ApiVersion { get; set; }
}