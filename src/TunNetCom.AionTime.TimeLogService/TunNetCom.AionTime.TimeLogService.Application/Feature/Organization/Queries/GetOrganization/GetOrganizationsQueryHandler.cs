using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TunNetCom.AionTime.TimeLogService.Application.Feature.Organization.Queries.GetOrganization
{
    public class GetOrganizationsQueryHandler(IGenericRepository<Organisation> organizationRepository, IMapper mapper) : IRequestHandler<GetOrganizationsQuery, IReadOnlyList<OrganizationRequest>>
    {
        private readonly IGenericRepository<Organisation> organizationRepository = organizationRepository;
        private readonly IMapper mapper = mapper;

        public async Task<IReadOnlyList<OrganizationRequest>> Handle(GetOrganizationsQuery request, CancellationToken cancellationToken)
        {
            var res = await this.organizationRepository.GetAsync();
            var organizations =this.mapper.Map<IReadOnlyList<OrganizationRequest>>(res);
            return organizations;
        }
    }
}
