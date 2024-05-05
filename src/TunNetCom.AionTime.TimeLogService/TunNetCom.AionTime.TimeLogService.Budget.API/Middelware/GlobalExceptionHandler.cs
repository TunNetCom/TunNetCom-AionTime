namespace TunNetCom.AionTime.TimeLogService.API.Middleware;

internal sealed class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
        CustomProblemDetails problem;
        switch (exception)
        {
            case BadRequestException:
                statusCode = HttpStatusCode.BadRequest;
                problem = new CustomProblemDetails
                {
                    Title = exception.Message,
                    Status = (int)statusCode,
                    Detail = exception.InnerException?.Message,
                    Type = exception.GetType().Name,
                };
                break;
            case NotFoundException:
                statusCode = HttpStatusCode.NotFound;
                problem = new CustomProblemDetails
                {
                    Title = exception.Message,
                    Status = (int)statusCode,
                    Detail = exception.InnerException?.Message,
                    Type = exception.GetType().Name,
                };
                break;
            default:
                problem = new CustomProblemDetails
                {
                    Title = exception.Message,
                    Status = (int)statusCode,
                    Detail = exception.InnerException?.Message,
                    Type = exception.GetType().Name,
                };
                break;
        }

        httpContext.Response.StatusCode = (int)statusCode;
        string logMessage = JsonConvert.SerializeObject(problem);
        _logger.LogError(logMessage);
        await httpContext.Response.WriteAsJsonAsync(problem, cancellationToken);

        return true;
    }
}
