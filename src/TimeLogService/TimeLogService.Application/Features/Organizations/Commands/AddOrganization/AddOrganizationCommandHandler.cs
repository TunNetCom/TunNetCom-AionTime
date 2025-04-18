using TunNetCom.AionTime.SharedKernel.Data;

namespace TimeLogService.Application.Features.Organizations.Commands.AddOrganization;

public class AddOrganizationCommandHandler(IRepository<Organization> organizationRepository, IMapper mapper)
    : IRequestHandler<AddOrganizationCommand, int>
{
    private readonly IRepository<Organization> _organizationRepository = organizationRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<int> Handle(AddOrganizationCommand request, CancellationToken cancellationToken)
    {
        Organization organization = _mapper.Map<Organization>(request.Organization);
        await _organizationRepository.AddAsync(organization);
        return organization.Id;
    }
}