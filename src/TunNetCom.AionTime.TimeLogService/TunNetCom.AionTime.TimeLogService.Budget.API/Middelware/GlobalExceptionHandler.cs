namespace TunNetCom.AionTime.TimeLogService.API.Middleware;

internal sealed class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> logger;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        this.logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
        var problem = new ProblemDetails
        {
            Title = exception.Message,
            Status = (int)statusCode,
            Detail = exception.InnerException?.Message,
            Type = exception.GetType().Name,
        };
        httpContext.Response.StatusCode = (int)statusCode;
        string logMessage = JsonConvert.SerializeObject(problem);
        this.logger.LogError(logMessage);
        await httpContext.Response.WriteAsJsonAsync(problem, cancellationToken);

        return true;
    }
}
