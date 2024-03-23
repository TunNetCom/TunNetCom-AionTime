namespace TunNetCom.AionTime.TimeLogService.Application.Feature.OrganizationAction.Queries.GetOrganizationById;

public class GetOrganizationQueryHandler(IGenericRepository<Organization> organizationRepository, IMapper mapper):IRequestHandler<GetOrganizationByIdQuery, OrganizationRequest>
{
    private readonly IGenericRepository<Organization> organizationRepository = organizationRepository;
    private readonly IMapper mapper = mapper;

    public async Task<OrganizationRequest> Handle(GetOrganizationByIdQuery request, CancellationToken cancellationToken)
    {
        var res = await this.organizationRepository.GetByIdAsync(request.id);
        var organization = this.mapper.Map<OrganizationRequest>(res);
        return organization;
    }
}
