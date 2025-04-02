using System.Threading;
using System.Threading.Tasks;
using Project = TimeLogService.Domain.Models.Dbo.Project;

namespace TimeLogService.Application.Feature.ProjectAction.Commands
{
    public class AddProjectCommandHandler(IRepository<Project> repository) : IRequestHandler<AddProjectCommand>
    {
        private readonly IRepository<Project> _repository = repository;

        public async Task Handle(AddProjectCommand request, CancellationToken cancellationToken)
        {
            await _repository.AddRangeAsync(request.Projects);
        }
    }
}