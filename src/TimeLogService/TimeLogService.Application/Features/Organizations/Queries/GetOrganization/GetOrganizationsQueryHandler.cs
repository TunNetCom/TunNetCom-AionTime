using TunNetCom.AionTime.SharedKernel.Data;

namespace TimeLogService.Application.Features.Organizations.Queries.GetOrganization;

public class GetOrganizationsQueryHandler(IRepository<Organization> organizationRepository, IMapper mapper)
    : IRequestHandler<GetOrganizationsQuery, IReadOnlyList<OrganizationRequest>>
{
    private readonly IRepository<Organization> _organizationRepository = organizationRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IReadOnlyList<OrganizationRequest>> Handle(
        GetOrganizationsQuery request,
        CancellationToken cancellationToken)
    {
        IReadOnlyList<Organization> organisationList = await _organizationRepository.GetAsync(cancellationToken);
        IReadOnlyList<OrganizationRequest> organizations =
            _mapper.Map<IReadOnlyList<OrganizationRequest>>(organisationList);

        return organizations;
    }
}