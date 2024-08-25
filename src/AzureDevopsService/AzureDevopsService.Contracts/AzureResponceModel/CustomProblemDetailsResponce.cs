namespace AzureDevopsService.Contracts.AzureResponceModel
{
    public class CustomProblemDetailsResponce : ProblemDetails
    {
        public string? Email { get; set; }

        public string? Path { get; set; }
    }
}