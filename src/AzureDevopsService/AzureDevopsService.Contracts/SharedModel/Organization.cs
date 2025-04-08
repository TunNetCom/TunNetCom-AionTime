namespace AzureDevopsService.Contracts.SharedModel
{
    public class Organization
    {
        public required string OrganizationName { get; set; }

        public required string OrganizationId { get; set; }

        // public required List<string> ProjectsIds { get; set; }
    }
}