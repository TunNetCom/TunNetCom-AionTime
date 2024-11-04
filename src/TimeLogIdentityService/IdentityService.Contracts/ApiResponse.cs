using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace IdentityService.Contracts;

public class ApiResponse<T>(T? data = default) : ApiResponse(data)
{
    public new T? Data { get; set; } = data;
}