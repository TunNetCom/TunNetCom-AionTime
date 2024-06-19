namespace AzureDevopsWebhookService.API.Controlleurs;

[Route("api/[controller]")]
[ApiController]
public class AzureDevopsServiceHookController : ControllerBase
{
    /// <summary>
    /// Old endpoint ===> tested
    /// </summary>
    /// <param name="webhookSubscription"></param>
    /// <returns></returns>
    [HttpPost("AzureEvents")]
    public IActionResult AzureEvents(AzureWebhookModelEvent<Resource> webhookSubscription)
    {
        return Ok(value: webhookSubscription);
    }

    /// <summary>
    /// Work item commented on
    /// Work item updated
    /// Work item restored
    /// Work item deleted
    /// Work item created
    /// </summary>
    /// <param name="webhookSubscription">Not tested</param>
    /// <returns></returns>
    [HttpPost("AzureWorkItemsEvents")]
    public IActionResult AzureWorkItemsEvents(AzureWebhookModelEvent<WorkItemResource> webhookSubscription)
    {
        return Ok(value: webhookSubscription);
    }

    /// <summary>
    /// Code checked in
    /// Code pushed
    /// Pull request created
    /// Pull request merge commit created
    /// Pull request updated
    /// </summary>
    /// <param name="webhookSubscription">Not tested</param>
    /// <returns></returns>
    [HttpPost("AzureCodeEvnts")]
    public IActionResult AzureCodeEvnts(AzureWebhookModelEvent<CodeResource> webhookSubscription)
    {
        return Ok(value: webhookSubscription);
    }

    /// <summary>
    /// Job state changed
    /// Run state changed
    /// Run stage state changed
    /// Run stage waiting for approval
    /// Run stage approval completed
    /// Run job state changed
    /// </summary>
    /// <param name="webhookSubscription">Not tested</param>
    /// <returns></returns>
    [HttpPost("AzurePipelinesEvnts")]
    public IActionResult AzurePipelinesEvnts(AzureWebhookModelEvent<PipeLinesResource> webhookSubscription)
    {
        return Ok(value: webhookSubscription);
    }

    /// <summary>
    /// Build completed
    /// Release created
    /// Release abandoned
    /// Release deployment approval completed
    /// Release deployment approval pending
    /// Release deployment completed
    /// Release deployment started
    /// </summary>
    /// <param name="webhookSubscription">Not tested</param>
    /// <returns></returns>
    [HttpPost("BuildAndReleaseEvnts")]
    public IActionResult BuildAndReleaseEvnts(AzureWebhookModelEvent<BuildAndReleaseResource> webhookSubscription)
    {
        return Ok(value: webhookSubscription);
    }
}