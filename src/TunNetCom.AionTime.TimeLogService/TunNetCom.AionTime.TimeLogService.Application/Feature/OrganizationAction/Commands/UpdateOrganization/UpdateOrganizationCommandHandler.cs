namespace TunNetCom.AionTime.TimeLogService.Application.Feature.OrganizationAction.Commands.UpdateOrganization;

public class UpdateOrganizationCommandHandler(IGenericRepository<Organization> organizationRepository, IMapper mapper) : IRequestHandler<UpdateOrganizationCommand, int>
{
    private readonly IGenericRepository<Organization> organizationRepository = organizationRepository;
    private readonly IMapper mapper = mapper;

    public async Task<int> Handle(UpdateOrganizationCommand request, CancellationToken cancellationToken)
    {
        var organization = this.mapper.Map<Organization>(request.organizationDTO);
        await this.organizationRepository.UpdateAsync(organization);
        return organization.Id;
    }
}
