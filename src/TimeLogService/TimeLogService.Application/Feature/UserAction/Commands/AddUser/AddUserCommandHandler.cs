using TimeLogService.Domain.Interfaces.Repositories;
using TimeLogService.Domain.Models;
using TimeLogService.Domain.Models.Dbo;

namespace TimeLogService.Application.Feature.UserAction.Commands.AddUser
{
    public class AddUserCommandHandler(IRepository<User> repository) : IRequestHandler<AddUserCommand>
    {
        private readonly IRepository<User> _repository = repository;

        public async Task Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            User user = new()
            {
                UserId = request.UserProfile!.Id,
                TenantId = string.Empty,
                CoreRevision = request.UserProfile!.CoreRevision,
                Revision = request.UserProfile!.Revision,
                TimeStamp = request.UserProfile!.TimeStamp,
                EmailAddress = request.UserProfile!.EmailAddress,
                PublicAlias = request.UserProfile!.PublicAlias,
            };

            await _repository.AddAsync(user);
        }
    }
}