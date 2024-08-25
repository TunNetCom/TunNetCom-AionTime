using AzureDevopsService.Contracts.AzureRequestResourceModel;
using AzureDevopsService.Contracts.AzureResponceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TunNetCom;
using TunNetCom.AionTime;
using TunNetCom.AionTime.AzureDevopsService;
using TunNetCom.AionTime.AzureDevopsService.Contracts;
using TunNetCom.AionTime.AzureDevopsService.Contracts.AzureRequestResourceModel;
using TunNetCom.AionTime.AzureDevopsService.Contracts.AzureResponceModel;

namespace AzureDevopsService.Contracts.AzureResponceModel;

public class WiqlBadRequestResponce : BaseRequest
{
    [JsonPropertyName("$id")]
    public string? Id { get; set; } = string.Empty;

    [JsonPropertyName("innerException")]
    public string? InnerException { get; set; } = string.Empty;

    [JsonPropertyName("message")]
    public string? Message { get; set; } = string.Empty;

    [JsonPropertyName("typeName")]
    public string? TypeName { get; set; } = string.Empty;

    [JsonPropertyName("typeKey")]
    public string? TypeKey { get; set; } = string.Empty;

    [JsonPropertyName("errorCode")]
    public int? ErrorCode { get; set; }

    [JsonPropertyName("eventId")]
    public int? EventId { get; set; }
}