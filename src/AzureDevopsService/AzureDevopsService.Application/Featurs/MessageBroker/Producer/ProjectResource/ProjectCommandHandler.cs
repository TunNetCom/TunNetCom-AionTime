namespace AzureDevopsService.Application.Featurs.MessageBroker.Producer.ProjectResource;

public class ProjectCommandHandler(IProjectService projectService, ISendEndpointProvider publishEndpointProvider) : IRequestHandler<ProjectCommand>
{
    private readonly IProjectService _projectService = projectService;
    private readonly ISendEndpointProvider _sendEndpointProvider = publishEndpointProvider;

    public async Task Handle(ProjectCommand request, CancellationToken cancellationToken)
    {
        ISendEndpoint endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("rabbitmq://rabbitmq/ProjectResponce"));

        OneOf<AllProjectResponce, CustomProblemDetailsResponce> projectsResponse = await _projectService.AllProjectUnderOrganization(request.Request);
        if (projectsResponse.IsT0)
        {
            await endpoint.Send(projectsResponse.AsT0, cancellationToken);
        }
        else
        {
            await endpoint.Send(projectsResponse.AsT1, cancellationToken);
        }
    }
}