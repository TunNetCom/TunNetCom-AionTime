using NPOI.SS.Formula.Functions;
using TimeLogService.Domain.Interfaces.Repositories;
using TimeLogService.Domain.Models;

namespace TimeLogService.Application.Feature.UserAction.Commands.AddUser
{
    public class AddUserCommandHandler(IRepository<User> repository, IMapper mapper) : IRequestHandler<AddUserCommand>
    {
        private readonly IRepository<User> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<OneOf<True,False>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {

            User user = new()
            {
                CoreRevision = request.UserProfile!.CoreRevision,
                EmailAddress = request.UserProfile!.EmailAddress,
                PublicAlias = request.UserProfile!.PublicAlias,
                Revision = request.UserProfile!.Revision,
                TimeStamp = request.UserProfile!.TimeStamp,
                UserId = request.UserProfile!.Id,
            };

            await _repository.AddAsync(user);
        }
    }
}