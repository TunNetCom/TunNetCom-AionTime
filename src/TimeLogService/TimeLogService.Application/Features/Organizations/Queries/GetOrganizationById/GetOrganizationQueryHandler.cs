﻿using TunNetCom.AionTime.SharedKernel.Data;

namespace TimeLogService.Application.Features.Organizations.Queries.GetOrganizationById;

public class GetOrganizationQueryHandler(IRepository<Organization> organizationRepository, IMapper mapper)
    : IRequestHandler<GetOrganizationByIdQuery, OrganizationRequest>
{
    private readonly IRepository<Organization> _organizationRepository = organizationRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<OrganizationRequest> Handle(GetOrganizationByIdQuery request, CancellationToken cancellationToken)
    {
        Organization? organization = await _organizationRepository.GetByIdAsync(request.Id, cancellationToken);
        OrganizationRequest organizationRequest = _mapper.Map<OrganizationRequest>(organization);

        // if (organizationRequest is null)
        // {
        //    throw new NotFoundException($"Cannot find organization with this Id {request.Id}");
        // }
        return organizationRequest;
    }
}