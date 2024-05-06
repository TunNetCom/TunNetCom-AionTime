namespace TunNetCom.AionTime.TimeLogService.Application;

public class GetOrganizationsQueryHandler(IRepository<Organization> organizationRepository, IMapper mapper)
    : IRequestHandler<GetOrganizationsQuery, IReadOnlyList<OrganizationRequest>>
{
    private readonly IRepository<Organization> _organizationRepository = organizationRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IReadOnlyList<OrganizationRequest>> Handle(
        GetOrganizationsQuery request,
        CancellationToken cancellationToken)
    {
        var res = await _organizationRepository.GetAsync();
        var organizations = _mapper.Map<IReadOnlyList<OrganizationRequest>>(res);
        if (organizations is null or [])
        {
            throw new NotFoundException("there's no organizations");
        }

        return organizations;
    }
}