namespace TunNetCom.AionTime.TimeLogService.Application;

public class GetOrganizationQueryHandler(IRepository<Organization> organizationRepository, IMapper mapper):IRequestHandler<GetOrganizationByIdQuery, OrganizationRequest>
{
    private readonly IRepository<Organization> organizationRepository = organizationRepository;
    private readonly IMapper mapper = mapper;

    public async Task<OrganizationRequest> Handle(GetOrganizationByIdQuery request, CancellationToken cancellationToken)
    {
        var res = await this.organizationRepository.GetByIdAsync(request.id);
        var organization = this.mapper.Map<OrganizationRequest>(res);
        if (organization is null)
            throw new NotFoundException($"Cannot find organization with this Id {request.id}");
        return organization;
    }
}
