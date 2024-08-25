using TimeLogService;
using TimeLogService.API;
using TimeLogService.API.Middelware;
using TimeLogService.API.Middelware;
using TunNetCom;
using TunNetCom.AionTime;

namespace TimeLogService.API.Middelware;

internal sealed class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger = logger;

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
        ProblemDetails problem;

        problem = new ProblemDetails
        {
            Title = exception.Message,
            Status = (int)statusCode,
            Detail = exception.InnerException?.Message,
            Type = exception.GetType().Name,
        };

        httpContext.Response.StatusCode = (int)statusCode;
        string logMessage = JsonConvert.SerializeObject(problem);
        _logger.LogError(logMessage);
        await httpContext.Response.WriteAsJsonAsync(problem, cancellationToken);

        return true;
    }
}