
namespace IdentityService.Domain.Models.Dbo
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(30)]
        public required string Name { get; set; }

        [MaxLength(30)]
        public required string LastName { get; set; }

        public bool IsPrincipalAccount { get; set; }

        [MaxLength(450)]
        public string? ParentId { get; set; }

        public AzureInfo? AzureInfo { get; set; }

        public GitHubInfo? GitHubInfo { get; set; }
    }
}