using System.ComponentModel.DataAnnotations;
using System.Reflection;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace IdentityService.Contracts.Constant
{
    public static class ErrorDetails
    {
        public const string InvalidUserName = "Invalid UserName";

        public const string InvalidPassword = "Invalid Password";

        public const string InvalidEmail = "Invalid Email";

        public const string InvalidUserId = "Invalid UserId";

        public const string InvalidOldPassword = "Invalid OldPassword";

        public const string UserNotFound = "User Not Found";

        public const string RoleNotFound = "Role Not Found";

        public const string RoleAssignmentFailed = "Role Assignment Failed";
    }
}