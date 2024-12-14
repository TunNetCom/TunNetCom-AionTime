﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace IdentityService.Domain.Models.Dbo
{
    public class AzureInfo
    {
        public int Id { get; set; }

        public required string UserId { get; set; } = null!;

        [MaxLength(100)]
        public required string EmailAddress { get; set; } = null!;

        public string PublicAlias { get; set; } = null!;

        public int CoreRevision { get; set; }

        public DateTime TimeStamp { get; set; }

        public int Revision { get; set; }

        public required string PublicKey { get; set; }

        public DateTime PublicKeyExpirationDate { get; set; }

        [ValidateNever]
        public required string IdentityUserId { get; set; }

        public ApplicationUser? User { get; set; }
    }
}