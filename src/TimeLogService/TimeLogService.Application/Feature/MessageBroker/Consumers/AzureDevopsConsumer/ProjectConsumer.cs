namespace TimeLogService.Application.Feature.MessageBroker.Consumers.AzureDevopsConsumer;

public class ProjectConsumer(ILogger<ProjectConsumer> logger) : IConsumer<GetOrganizationProjectsResponse>, IConsumer<CustomProblemDetailsResponce>
{
    private readonly ILogger<ProjectConsumer> _logger = logger;

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
    public async Task Consume(ConsumeContext<GetOrganizationProjectsResponse> context)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
    {
        _logger.LogInformation(JsonConvert.SerializeObject(context.Message));
    }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
    public async Task Consume(ConsumeContext<CustomProblemDetailsResponce> context)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
    {
        _logger.LogInformation(JsonConvert.SerializeObject(context.Message));
    }
}