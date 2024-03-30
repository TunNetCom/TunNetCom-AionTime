namespace TunNetCom.AionTime.TimeLogService.Application.Feature.OrganizationAction.Commands.DeletOrganization;

public class DeleteOrganizationCommandHandler(IRepository<Organization> organizationRepository, IMapper mapper) : IRequestHandler<DeleteOrganizationCommand, int>
{
    private readonly IMapper mapper=mapper;
    private readonly IRepository<Organization> organizationRepository = organizationRepository;

    public async Task<int> Handle(DeleteOrganizationCommand request, CancellationToken cancellationToken)
    {
        await this.organizationRepository.DeleteAsync(request.id);
        return request.id;
    }
}
