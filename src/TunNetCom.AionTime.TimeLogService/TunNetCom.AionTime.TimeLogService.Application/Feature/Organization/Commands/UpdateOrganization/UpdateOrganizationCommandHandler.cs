namespace TunNetCom.AionTime.TimeLogService.Application.Feature.Organization.Commands.UpdateOrganization;

public class UpdateOrganizationCommandHandler(IGenericRepository<Organisation> organizationRepository, IMapper mapper) : IRequestHandler<UpdateOrganizationCommand, int>
{
    private readonly IGenericRepository<Organisation> organizationRepository = organizationRepository;
    private readonly IMapper mapper = mapper;

    public async Task<int> Handle(UpdateOrganizationCommand request, CancellationToken cancellationToken)
    {
        var organization = this.mapper.Map<Organisation>(request.organizationDTO);
        await this.organizationRepository.UpdateAsync(organization);
        return organization.Id;
    }
}
