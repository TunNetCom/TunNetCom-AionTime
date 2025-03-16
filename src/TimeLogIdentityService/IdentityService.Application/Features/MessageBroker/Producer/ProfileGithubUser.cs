using IdentityService.Application.Features.InternalTreatement.Events.TenatCreated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IdentityService.Application.Features.MessageBroker.Producer;

public class ProfileGithubUser : INotificationHandler<TenantCreatedNotification>
{
    public Task Handle(TenantCreatedNotification notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}