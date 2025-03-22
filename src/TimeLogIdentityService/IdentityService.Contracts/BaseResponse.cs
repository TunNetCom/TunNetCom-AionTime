namespace IdentityService.Contracts;

public class ApiResponse(object? data = null)
{
    public bool Succeeded { get; set; } = false;

    public object? Data { get; set; } = data;

    public ProblemDetails? Error { get; set; } = new();
}