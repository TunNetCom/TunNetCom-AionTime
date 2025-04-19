﻿using TunNetCom.AionTime.SharedKernel.Data;

namespace TimeLogService.Application.Features.Organizations.Commands.UpdateOrganization;

public class UpdateOrganizationCommandHandler(IRepository<Organization> organizationRepository, IMapper mapper)
    : IRequestHandler<UpdateOrganizationCommand, int>
{
    private readonly IRepository<Organization> _organizationRepository = organizationRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<int> Handle(UpdateOrganizationCommand request, CancellationToken cancellationToken)
    {
        Organization organization = _mapper.Map<Organization>(request.Organization);
        await _organizationRepository.UpdateAsync(organization, cancellationToken);
        return organization.Id;
    }
}