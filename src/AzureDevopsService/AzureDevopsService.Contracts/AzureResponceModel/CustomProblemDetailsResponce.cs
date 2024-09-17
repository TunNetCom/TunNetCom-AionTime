namespace AzureDevopsService.Contracts.AzureResponceModel;

public class CustomProblemDetailsResponce : ProblemDetails
{
    public string Email { get; set; } = string.Empty;

    public string Path { get; set; } = string.Empty;
}