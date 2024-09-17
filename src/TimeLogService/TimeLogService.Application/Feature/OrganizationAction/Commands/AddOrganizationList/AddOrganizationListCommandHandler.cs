using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TimeLogService.Application.Feature.OrganizationAction.Commands.AddOrganizationList
{
    public class AddOrganizationListCommandHandler(IRepository<Organization> repository) : IRequestHandler<AddOrganizationListCommand>
    {
        private readonly IRepository<Organization> _repository = repository;

        public async Task Handle(AddOrganizationListCommand request, CancellationToken cancellationToken)
        {
            await _repository.AddRangeAsync(request.Organizations);
        }
    }
}
