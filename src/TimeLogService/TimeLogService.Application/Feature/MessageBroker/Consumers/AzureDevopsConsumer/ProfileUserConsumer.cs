namespace TimeLogService.Application.Feature.MessageBroker.Consumers.AzureDevopsConsumer;

public class ProfileUserConsumer(
    ILogger<ProfileUserConsumer> logger,
    IMediator mediator,
    IRepository<User> repository,
    IRepository<Organization> repositoryOrganization)
    : IConsumer<UserProfile>, IConsumer<CustomProblemDetailsResponce>
{
    private readonly ILogger<ProfileUserConsumer> _logger = logger;
    private readonly IMediator _mediator = mediator;
    private readonly IRepository<User> _repository = repository;
    private readonly IRepository<Organization> _repositoryOrganization = repositoryOrganization;

    public async Task Consume(ConsumeContext<UserProfile> context)
    {
        User? user = await _repository.GetSingleAsync(x => x.UserId == context.Message!.Id);

        if (user is null)
        {
            await _mediator.Send(new AddUserCommand(context.Message));
        }

        if (context.Message.UserAccount is not null && context.Message.UserAccount.Count > 0)
        {
            IReadOnlyList<Organization> organizationList = await _repositoryOrganization
                .GetManyAsync(x => x.UserId == context.Message!.Id);

            HashSet<string> existingAccountIds = [.. organizationList.Select(x => x.AccountId)];

            List<Organization> organizations = [];

            foreach (UserOrganization org in context.Message.UserAccount!.Value)
            {
                if (!existingAccountIds.Contains(org.AccountId)
                    && org.AccountUri is not null)
                {
                    organizations.Add(new Organization
                    {
                        AccountId = org!.AccountId,
                        TenantId = string.Empty,
                        AccountUri = org.AccountUri,
                        Name = org.AccountName,
                        UserId = context.Message!.Id,
                        IsAionTimeApproved = false,
                    });
                }
            }

            if (organizations.Count > 0)
            {
                await _mediator.Send(new AddOrganizationListCommand(organizations.AsReadOnly()));
            }
        }

        _logger.LogInformation(JsonConvert.SerializeObject(context.Message));
    }

    public async Task Consume(ConsumeContext<CustomProblemDetailsResponce> context)
    {
        await Task.Delay(1);
        _logger.LogInformation(JsonConvert.SerializeObject(context.Message));
    }
}