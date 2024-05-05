namespace TunNetCom.AionTime.TimeLogService.Application;

public class AddOrganizationCommandHandler(IRepository<Organization> organizationRepository, IMapper mapper)
    : IRequestHandler<AddOrganizationCommand, int>
{
    private readonly IRepository<Organization> _organizationRepository = organizationRepository;
    private readonly IMapper _mapper = mapper;

    async Task<int> IRequestHandler<AddOrganizationCommand, int>.Handle(AddOrganizationCommand request, CancellationToken cancellationToken)
    {
        var organization = _mapper.Map<Organization>(request.Organization);
        await _organizationRepository.AddAsync(organization);
        return organization.Id;
    }
}
