using AzureDevopsService.Contracts.AzureResponceModel;
using IdentityService.Application.Features.InternalTreatement.AddAzureInfo;
using IdentityService.Domain.Models.Dbo;
using IdentityService.Infrastructure.DbContext;
using MassTransit;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Features.MessageBroker.Consumer
{
    public class IdentityConsumer(IMediator mediator, ILogger<IdentityConsumer> logger) :
        IConsumer<UserProfile>,
        IConsumer<CustomProblemDetailsResponce>
    {
        private readonly IMediator _mediator = mediator;
        private readonly ILogger<IdentityConsumer> _logger = logger;

        public async Task Consume(ConsumeContext<UserProfile> context)
        {
            await _mediator.Send(new AddAzureInfoCommand(context.Message));
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task Consume(ConsumeContext<CustomProblemDetailsResponce> context)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
#pragma warning restore format
        {
            _logger.LogInformation(JsonConvert.SerializeObject(context.Message));
        }
    }
}