namespace TunNetCom.AionTime.TimeLogService.Application.Feature.Organization.Commands.DeletOrganization;

public class DeleteOrganizationCommandHandler(IGenericRepository<Organisation> organizationRepository, IMapper mapper) : IRequestHandler<DeleteOrganizationCommand, int>
{
    private readonly IMapper mapper=mapper;
    private readonly IGenericRepository<Organisation> organizationRepository = organizationRepository;

    public async Task<int> Handle(DeleteOrganizationCommand request, CancellationToken cancellationToken)
    {
        var organization = this.mapper.Map<Organisation>(request.organization);
        await this.organizationRepository.DeleteAsync(organization);
        return organization.Id;
    }
}
