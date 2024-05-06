namespace TunNetCom.AionTime.TimeLogService.Application;

public class DeleteOrganizationCommandHandler(IRepository<Organization> organizationRepository)
    : IRequestHandler<DeleteOrganizationCommand, int>
{
    private readonly IRepository<Organization> _organizationRepository = organizationRepository;

    public async Task<int> Handle(DeleteOrganizationCommand request, CancellationToken cancellationToken)
    {
        await _organizationRepository.DeleteAsync(request.Id);
        return request.Id;
    }
}