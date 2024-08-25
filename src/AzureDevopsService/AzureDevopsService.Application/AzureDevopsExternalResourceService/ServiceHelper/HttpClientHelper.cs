namespace AzureDevopsService.Application.AzureDevopsExternalResourceService.ServiceHelper;

public static class HttpClientHelper
{
    public static void SetAuthHeader(HttpClient client, string? pat)
    {
        byte[] byteArray = Encoding.ASCII.GetBytes($"{"AzureDevopsGlobalPath"}:{pat}");

        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
    }
}