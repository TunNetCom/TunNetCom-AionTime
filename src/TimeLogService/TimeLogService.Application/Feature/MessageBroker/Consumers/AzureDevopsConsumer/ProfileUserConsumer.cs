namespace TimeLogService.Application.Feature.MessageBroker.Consumers.AzureDevopsConsumer;

public class ProfileUserConsumer(
    ILogger<ProfileUserConsumer> logger,
    IMediator mediator,
    IRepository<Organization> repositoryOrganization)
    : IConsumer<GetAzureAdminInfoResponse>, IConsumer<CustomProblemDetailsResponce>
{
    private readonly ILogger<ProfileUserConsumer> _logger = logger;
    private readonly IMediator _mediator = mediator;
    private readonly IRepository<Organization> _repositoryOrganization = repositoryOrganization;

    public async Task Consume(ConsumeContext<GetAzureAdminInfoResponse> context)
    {
        if (context.Message.UserOrganization is not null && context.Message.UserOrganization.Count > 0)
        {
            IReadOnlyList<Organization> organizationList = await _repositoryOrganization
                .GetManyAsync(x => x.TenantId == context.Message!.TenantId);

            HashSet<string> existingAccountIds = [.. organizationList.Select(x => x.AccountId)];

            List<Organization> organizations = [];

            foreach (AzureOrganizationValue org in context.Message.UserOrganization!.Value)
            {
                if (!existingAccountIds.Contains(org.AccountId)
                    && org.AccountUri is not null)
                {
                    organizations.Add(new Organization
                    {
                        AccountId = org!.AccountId,
                        TenantId = context.Message!.TenantId,
                        AccountUri = org.AccountUri,
                        Name = org.AccountName,
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