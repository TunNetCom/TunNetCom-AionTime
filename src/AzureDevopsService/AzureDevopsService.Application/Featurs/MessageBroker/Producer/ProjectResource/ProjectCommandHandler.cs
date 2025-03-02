namespace AzureDevopsService.Application.Featurs.MessageBroker.Producer.ProjectResource;

public class ProjectCommandHandler(IProjectService projectService, ISendEndpointProvider publishEndpointProvider) : IRequestHandler<ProjectCommand>
{
    private readonly IProjectService _projectService = projectService;
    private readonly ISendEndpointProvider _sendEndpointProvider = publishEndpointProvider;

    public async Task Handle(ProjectCommand request, CancellationToken cancellationToken)
    {
        ISendEndpoint endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("rabbitmq://rabbitmq/ProjectResponce"));

        OneOf<OrganizationProjects, CustomProblemDetailsResponce> projectsResponse = await _projectService.AllProjectUnderOrganization(request.Request);
        if (projectsResponse.IsT0)
        {
            GetOrganizationProjectsResponse organizationProjectsResponse = new()
            {
                Email = request.Request.Email,
                Path = request.Request.Path,
                OrganizationId = request.Request.OrganizationId,
                OrganizationName = request.Request.OrganizationName,
                OrganizationProjects = projectsResponse.AsT0,
            };
            await endpoint.Send(organizationProjectsResponse, cancellationToken);
        }
        else
        {
            await endpoint.Send(projectsResponse.AsT1, cancellationToken);
        }
    }
}