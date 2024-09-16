using System.Collections.Generic;
using TimeLogService.Application.Feature.OrganizationAction.Commands.AddOrganization;
using TimeLogService.Application.Feature.OrganizationAction.Commands.AddOrganizationList;
using TimeLogService.Application.Feature.UserAction.Commands.AddUser;

namespace TimeLogService.Application.Feature.MessageBroker.Consumer.ProfileUser;

public class ProfileUserConsumer(ILogger<ProfileUserConsumer> logger, IMediator mediator, IRepository<User> repository, IRepository<Organization> repositoryOrganization) : IConsumer<UserProfile>, IConsumer<CustomProblemDetailsResponce>
{
    private readonly ILogger<ProfileUserConsumer> _logger = logger;
    private readonly IMediator _mediator = mediator;
    private readonly IRepository<User> _repository = repository;
    private readonly IRepository<Organization> _repositoryOrganization = repositoryOrganization;

    public async Task Consume(ConsumeContext<UserProfile> context)
    {
        User user = await _repository.GetSingleAsync(x => x.UserId == context.Message.Id);

        if (user is null)
        {
            await _mediator.Send(new AddUserCommand(context.Message));

            if (context.Message.UserAccount.Count > 0)
            {
                IReadOnlyList<Organization> organizationList = await _repositoryOrganization.GetManyAsync(x => x.UserId == context.Message!.Id);

                var existingAccountIds = new HashSet<string>(organizationList.Select(x => x.AccountId));

                List<Organization> organizations = new List<Organization>();

                foreach (UserOrganization org in context.Message.UserAccount!.Value)
                {
                    if (!existingAccountIds.Contains(org.AccountId))
                    {
                        organizations.Add(new Organization
                        {
                            AccountId = org.AccountId,
                            AccountUri = org.AccountUri.ToString(),
                            Name = org.AccountName,
                            UserId = context.Message.Id,
                            IsAionTimeApproved = false,
                        });
                    }
                }

                if (organizations.Count > 0)
                {
                    await _mediator.Send(new AddOrganizationListCommand(organizations));
                }
            }
        }

        _logger.LogInformation(JsonConvert.SerializeObject(context.Message));
    }

#pragma warning disable format
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
    public async Task Consume(ConsumeContext<CustomProblemDetailsResponce> context)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
#pragma warning restore format
    {
        _logger.LogInformation(JsonConvert.SerializeObject(context.Message));
    }
}