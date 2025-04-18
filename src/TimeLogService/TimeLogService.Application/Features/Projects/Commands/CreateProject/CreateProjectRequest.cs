namespace TimeLogService.Application.Features.Projects.Commands.CreateProject;

public record CreateProjectRequest
{
    public required int OrganizationId { get; set; }

    public Guid AzureProjectId { get; set; }

    public required string Name { get; set; }

    public required string State { get; set; }

    public string? Visibility { get; set; }

    public DateTime? LastUpdateTime { get; set; }
}
