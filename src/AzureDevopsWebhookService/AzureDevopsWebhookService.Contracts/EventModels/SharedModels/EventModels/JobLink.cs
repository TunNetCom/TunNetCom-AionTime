using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureDevopsWebhookService.Contracts.EventModels.SharedModels.EventModels;

public record class JobLink(
    [property: JsonProperty(PropertyName = "System.AreaPath", NullValueHandling = NullValueHandling.Ignore)]
    Url? Web,

    [property: JsonProperty(PropertyName = "System.AreaPath", NullValueHandling = NullValueHandling.Ignore)]
    Url? PipeLineWeb,

    [property: JsonProperty(PropertyName = "System.AreaPath", NullValueHandling = NullValueHandling.Ignore)]
    string? SystemAreaPath);