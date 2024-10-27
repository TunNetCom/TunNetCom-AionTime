#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace IdentityService.Contracts;

public class LoginResponse
{
    public string? Token { get; set; }
}