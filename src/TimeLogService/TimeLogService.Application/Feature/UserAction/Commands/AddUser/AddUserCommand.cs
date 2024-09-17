using NPOI.SS.Formula.Functions;
using OneOf;

namespace TimeLogService.Application.Feature.UserAction.Commands.AddUser;

public record class AddUserCommand(UserProfile UserProfile) : IRequest;