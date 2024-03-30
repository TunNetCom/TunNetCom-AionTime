namespace TunNetCom.AionTime.TimeLogService.Application.Feature.OrganizationAction.Queries.GetOrganization;

public class GetOrganizationsQueryHandler(IRepository<Organization> organizationRepository, IMapper mapper) : IRequestHandler<GetOrganizationsQuery, IReadOnlyList<OrganizationRequest>>
{
    private readonly IRepository<Organization> organizationRepository = organizationRepository;
    private readonly IMapper mapper = mapper;

    public async Task<IReadOnlyList<OrganizationRequest>> Handle(GetOrganizationsQuery request, CancellationToken cancellationToken)
    {
        var res = await this.organizationRepository.GetAsync();
        var organizations =this.mapper.Map<IReadOnlyList<OrganizationRequest>>(res);
        return organizations;
    }
}
