namespace TunNetCom.AionTime.TimeLogService.Application;

public class NotFoundException : Exception
{
    public NotFoundException(string message)
        : base(message)
    {
    }
}
