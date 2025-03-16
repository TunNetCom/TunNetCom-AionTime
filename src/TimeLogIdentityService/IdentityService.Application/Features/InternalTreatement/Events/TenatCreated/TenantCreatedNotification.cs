using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Features.InternalTreatement.Events.TenatCreated;

public record class TenantCreatedNotification(Guid TenantId, string AzureDevOpsPath, string GithubPath, string UserEmail) : INotification;