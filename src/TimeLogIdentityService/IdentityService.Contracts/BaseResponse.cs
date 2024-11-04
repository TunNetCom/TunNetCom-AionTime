using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace IdentityService.Contracts
{
    public class ApiResponse(object? data = null)
    {
        public bool Succeeded { get; set; }

        public object? Data { get; set; } = data;

        public ProblemDetails? Error { get; set; } = new();
    }
}