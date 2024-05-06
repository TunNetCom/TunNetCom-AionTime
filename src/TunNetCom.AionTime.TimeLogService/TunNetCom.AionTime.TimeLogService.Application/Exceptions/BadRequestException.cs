namespace TunNetCom.AionTime.TimeLogService.Application;

public class BadRequestException : Exception
{
    public BadRequestException(string message)
        : base(message)
    {
    }
}