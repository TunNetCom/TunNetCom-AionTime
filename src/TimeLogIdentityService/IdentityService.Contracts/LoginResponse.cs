using Newtonsoft.Json;

namespace IdentityService.Contracts;

public class LoginResponse
{
    public string? Token { get; set; }
}