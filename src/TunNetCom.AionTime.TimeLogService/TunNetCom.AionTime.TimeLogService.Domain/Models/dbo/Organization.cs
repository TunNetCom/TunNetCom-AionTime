namespace TunNetCom.AionTime.TimeLogService.Domain.Models.Dbo;

public partial class Organization : BaseEntity
{
    private readonly List<Project> _projects;

    protected Organization(string name)
    {
        Name = name;
        _projects = [];
    }

    public IReadOnlyCollection<Project> Projects => _projects.AsReadOnly();

    public string Name { get; private set; }
}