using AzureDevopsService.Contracts.AzureResponceModel;
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
    public class IdentityConsumer(UserManager<ApplicationUser> userManager, AuthContext authContext, ILogger<IdentityConsumer> logger) :
        IConsumer<UserProfile>,
        IConsumer<CustomProblemDetailsResponce>
    {
        private readonly UserManager<ApplicationUser> _userManager = userManager;
        private readonly AuthContext _authContext = authContext;
        private readonly ILogger<IdentityConsumer> _logger = logger;

        public async Task Consume(ConsumeContext<UserProfile> context)
        {
            ApplicationUser? user = await _userManager.FindByEmailAsync(context.Message.EmailAddress);

            if (user == null)
            {
                _logger.LogError($"the user {context.Message.Email} not found");
            }

            AzureInfo azureInfo = new()
            {
                IdentityUserId = user!.Id,
                EmailAddress = context.Message.Email,
                PublicAlias = context.Message.PublicAlias,
                PublicKey = context.Message.Path,
                UserId = context.Message.Id,
                Revision = context.Message.Revision,
                PublicKeyExpirationDate = DateTime.Now,
                CoreRevision = context.Message.CoreRevision,
                User = user,
                TimeStamp = context.Message.TimeStamp,
            };

            _ = await _authContext.AzureInfo.AddAsync(azureInfo);
            _ = await _authContext.SaveChangesAsync();
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