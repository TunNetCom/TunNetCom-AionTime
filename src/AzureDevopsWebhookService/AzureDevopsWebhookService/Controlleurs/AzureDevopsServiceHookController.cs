namespace AzureDevopsWebhookService.API.Controlleurs;

[Route("api/[controller]")]
[ApiController]
public class AzureDevopsServiceHookController : ControllerBase
{
    [HttpPost("AzureEvents")]
    public IActionResult AzureEvents(BaseModelEvent webhookSubscription)
    {
        return Ok(value: webhookSubscription);
    }
}