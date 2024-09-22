using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeLogService.Domain.Models.Dbo;

namespace TimeLogService.Application.Feature.OrganizationAction.Commands.AddOrganizationList;

public record class AddOrganizationListCommand(List<Organization> Organizations) : IRequest;
