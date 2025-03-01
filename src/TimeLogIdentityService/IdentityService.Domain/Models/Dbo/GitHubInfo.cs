
namespace IdentityService.Domain.Models.Dbo
{
    public class GitHubInfo
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string Key { get; set; }

        public DateTime ExpirationDate { get; set; }

        [ValidateNever]
        public required string IdentityUserId { get; set; }

        public required ApplicationUser User { get; set; }
    }
}