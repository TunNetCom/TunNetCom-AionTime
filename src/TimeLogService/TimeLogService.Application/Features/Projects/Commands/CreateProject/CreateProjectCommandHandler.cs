//using TunNetCom.AionTime.SharedKernel.Data;

//namespace TimeLogService.Application.Features.ProjectActions.Commands;

//public class CreateProjectCommandHandler(
//    IRepository<Project> projectRepository,
//    ILogger<CreateProjectCommandHandler> logger) 
//    : IRequestHandler<CreateProjectCommand, int>
//{
//    public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
//    {
//        Project project = new Project
//        {
//            Name = request.Name,
//            OrganizationId = request.OrganizationId,
//            AzureProjectId = request.AzureProjectId,
//            State = request.State,
//            Visibility = request.Visibility,
//            LastUpdateTime = request.LastUpdateTime,
//        };
//    }
//}