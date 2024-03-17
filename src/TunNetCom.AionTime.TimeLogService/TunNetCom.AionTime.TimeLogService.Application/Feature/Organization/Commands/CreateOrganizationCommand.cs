namespace TunNetCom.AionTime.TimeLogService.Application.Feature.Organization.Commands
{
    using MediatR;
    using TunNetCom.AionTime.TimeLogService.Domain.Interfaces.Repository;
    using TunNetCom.AionTime.TimeLogService.Domain.Models;

    public class CreateOrganizationCommand(IGenericRepository<Organisation> organizationRepository) : IRequestHandler<Organisation, int>
    {
        private readonly IGenericRepository<Organisation> organizationRepository = organizationRepository;

        public async Task<int> Handle(Organisation request, CancellationToken cancellationToken)
        {
           await this.organizationRepository.AddAsync(request);
           return request.Id;
        }
    }
}
