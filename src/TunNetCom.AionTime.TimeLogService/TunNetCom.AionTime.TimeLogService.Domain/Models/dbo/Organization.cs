namespace TunNetCom.AionTime.TimeLogService.Domain.Models.Dbo;

public partial class Organization(IEnumerable<Project> projects, string name) : BaseEntity
{
    private readonly List<Project> _projects = projects.ToList();

    public IReadOnlyCollection<Project> Projects => _projects.AsReadOnly();

    public string Name { get; set; } = name;
}