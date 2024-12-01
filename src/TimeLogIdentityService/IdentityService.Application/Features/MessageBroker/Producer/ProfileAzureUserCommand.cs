using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Features.MessageBroker.Producer;

public record class ProfileAzureUserCommand(string Email, string Path) : IRequest;