using AzureDevopsService;
using AzureDevopsService.Application;
using AzureDevopsService.Application.Featurs;
using AzureDevopsService.Application.Featurs.MessageBroker;
using AzureDevopsService.Application.Featurs.MessageBroker.Producer;
using AzureDevopsService.Application.Featurs.MessageBroker.Producer.ProjectResource;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AzureDevopsService.Application.Featurs.MessageBroker.Producer.ProjectResource
{
    public class ProjectCommandHandler(IProjectService projectService, ISendEndpointProvider publishEndpointProvider) : IRequestHandler<ProjectCommand>
    {
        private readonly IProjectService _projectService = projectService;
        private readonly ISendEndpointProvider _sendEndpointProvider = publishEndpointProvider;

        public async Task Handle(ProjectCommand request, CancellationToken cancellationToken)
        {
            ISendEndpoint endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("rabbitmq://rabbitmq/ProjectResponce"));

            OneOf<AllProjectResponce?, CustomProblemDetailsResponce?> projectsResponse = await _projectService.AllProjectUnderOrganization(request.Request);
            if (projectsResponse.IsT0)
            {
#pragma warning disable CS8634 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'class' constraint.
                await endpoint.Send(projectsResponse.AsT0, cancellationToken);
#pragma warning restore CS8634 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'class' constraint.
            }
            else
            {
#pragma warning disable CS8634 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'class' constraint.
                await endpoint.Send(projectsResponse.AsT1, cancellationToken);
#pragma warning restore CS8634 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'class' constraint.
            }
        }
    }
}