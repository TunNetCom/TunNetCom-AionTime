using TimeLogService.Domain.Interfaces.Repositories;

namespace TimeLogService.Application.Feature.UserAction.Commands.AddUser
{
    public class AddUserCommandHandler(IRepository<User> repository) : IRequestHandler<AddUserCommand>
    {
        private readonly IRepository<User> _repository = repository;

        public async Task Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            await _repository.AddAsync(request.UserProfile);
        }
    }
}
