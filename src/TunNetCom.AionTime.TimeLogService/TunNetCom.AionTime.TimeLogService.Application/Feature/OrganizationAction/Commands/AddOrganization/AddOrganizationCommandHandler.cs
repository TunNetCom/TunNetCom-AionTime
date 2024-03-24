namespace TunNetCom.AionTime.TimeLogService.Application.Feature.OrganizationAction.Commands.AddOrganization;

public class AddOrganizationCommandHandler(IGenericRepository<Organization> organizationRepository, IMapper mapper) : IRequestHandler<AddOrganizationCommand, int>
{
    private readonly IGenericRepository<Organization> organizationRepository = organizationRepository;
    private readonly IMapper mapper = mapper;

    async Task<int> IRequestHandler<AddOrganizationCommand, int>.Handle(AddOrganizationCommand request, CancellationToken cancellationToken)
    {
        var organization = this.mapper.Map<Organization>(request.organizationDTO);
        await this.organizationRepository.AddAsync(organization);
        return organization.Id;
    }
}
