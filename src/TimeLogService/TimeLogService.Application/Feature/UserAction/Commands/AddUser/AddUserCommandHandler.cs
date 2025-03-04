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
            User user = new
                (
                coreRevision: request.UserProfile!.CoreRevision,
                emailAddress: request.UserProfile!.EmailAddress,
                publicAlias: request.UserProfile!.PublicAlias,
                revision: request.UserProfile!.Revision,
                timeStamp: request.UserProfile!.TimeStamp,
                userId: request.UserProfile!.Id);

            await _repository.AddAsync(user);
        }
    }
}