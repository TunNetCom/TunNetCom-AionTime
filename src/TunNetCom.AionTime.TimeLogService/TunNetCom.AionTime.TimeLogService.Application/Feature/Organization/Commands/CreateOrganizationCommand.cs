using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TunNetCom.AionTime.TimeLogService.Domain.Interfaces.Repository;
using TunNetCom.AionTime.TimeLogService.Domain.Models;

namespace TunNetCom.AionTime.TimeLogService.Application.Feature.Organization.Commands
{
    public class CreateOrganizationCommand : IRequestHandler<Organisation, Unit>
    {
        private readonly IOrganisationRepository _organisationRepository;
        public CreateOrganizationCommand(IOrganisationRepository organisationRepository) {
            _organisationRepository = organisationRepository;
        }
        public async Task<Unit> Handle(Organisation request, CancellationToken cancellationToken)
        {
            await _organisationRepository.AddOrganization(request);
            return Unit.Value;
        }
    }
}
