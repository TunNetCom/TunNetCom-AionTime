namespace TimeLogService.Application.Featurs.OrganizationActions.Commands.AddOrganizationList
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