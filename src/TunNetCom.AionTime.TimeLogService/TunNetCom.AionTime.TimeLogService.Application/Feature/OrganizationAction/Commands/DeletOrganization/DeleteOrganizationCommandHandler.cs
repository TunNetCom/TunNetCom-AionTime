namespace TunNetCom.AionTime.TimeLogService.Application.Feature.OrganizationAction.Commands.DeletOrganization;

public class DeleteOrganizationCommandHandler(IGenericRepository<Organization> organizationRepository, IMapper mapper) : IRequestHandler<DeleteOrganizationCommand, int>
{
    private readonly IMapper mapper=mapper;
    private readonly IGenericRepository<Organization> organizationRepository = organizationRepository;

    public async Task<int> Handle(DeleteOrganizationCommand request, CancellationToken cancellationToken)
    {
        var organization = this.mapper.Map<Organization>(request.organization);
        await this.organizationRepository.DeleteAsync(organization);
        return organization.Id;
    }
}
