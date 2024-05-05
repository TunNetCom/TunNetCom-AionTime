namespace TunNetCom.AionTime.TimeLogService.Application;

public class GetOrganizationQueryHandler(IRepository<Organization> organizationRepository, IMapper mapper)
    : IRequestHandler<GetOrganizationByIdQuery, OrganizationRequest>
{
    private readonly IRepository<Organization> _organizationRepository = organizationRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<OrganizationRequest> Handle(GetOrganizationByIdQuery request, CancellationToken cancellationToken)
    {
        var res = await _organizationRepository.GetByIdAsync(request.Id);
        var organization = _mapper.Map<OrganizationRequest>(res);
        if (organization is null)
        {
            throw new NotFoundException($"Cannot find organization with this Id {request.Id}");
        }

        return organization;
    }
}
