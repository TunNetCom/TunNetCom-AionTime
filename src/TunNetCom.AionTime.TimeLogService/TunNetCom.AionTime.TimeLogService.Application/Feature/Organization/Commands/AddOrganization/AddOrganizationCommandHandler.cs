namespace TunNetCom.AionTime.TimeLogService.Application.Feature.Organization.Commands.AddOrganization;

public class AddOrganizationCommandHandler(IGenericRepository<Organisation> organizationRepository, IMapper mapper) : IRequestHandler<AddOrganizationCommand, int>
{
    private readonly IGenericRepository<Organisation> organizationRepository = organizationRepository;
    private readonly IMapper mapper = mapper;

    async Task<int> IRequestHandler<AddOrganizationCommand, int>.Handle(AddOrganizationCommand request, CancellationToken cancellationToken)
    {
        var organization = this.mapper.Map<Organisation>(request.organizationDTO);
        await this.organizationRepository.AddAsync(organization);
        return organization.Id;
    }
}
