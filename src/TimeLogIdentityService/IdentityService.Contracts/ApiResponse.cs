using Microsoft.AspNetCore.Mvc;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace IdentityService.Contracts;

public class ApiResponse<T>
{
    public bool Success { get; set; }

    public T? Data { get; set; }

    public ProblemDetails? Error { get; set; } = new();
}