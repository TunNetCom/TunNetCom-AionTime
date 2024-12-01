using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace IdentityService.Domain.Models.Dbo
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(30)]
        public string Name { get; set; }

        [MaxLength(30)]
        public string LastName { get; set; }

        public bool IsPrincipalAccount { get; set; }

        [MaxLength(450)]
        public string? ParentId { get; set; }
    }
}