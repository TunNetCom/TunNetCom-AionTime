using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeLogService;
using TimeLogService.Application;
using TimeLogService.Domain.Models.Dbo;

namespace TimeLogService.Application.Featurs.OrganizationActions.Commands.AddOrganizationList;

public record class AddOrganizationListCommand(ReadOnlyCollection<Organization> Organizations) : IRequest;