using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IdentityService.Contracts
{
    public class ApiResponse(object? data = null)
    {
        public bool Succeeded { get; set; }

        public object? Data { get; set; } = data;

        public ProblemDetails? Error { get; set; } = new();
    }
}