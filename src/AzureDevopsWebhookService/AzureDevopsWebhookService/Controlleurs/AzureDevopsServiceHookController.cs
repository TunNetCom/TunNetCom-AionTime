namespace AzureDevopsWebhookService.API.Controlleurs;

[Route("api/[controller]")]
[ApiController]
public class AzureDevopsServiceHookController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    /// <summary>
    /// Old endpoint ===> tested
    /// </summary>
    /// <param name="webhookSubscription"></param>
    /// <returns></returns>
    [HttpPost("AzureEvents")]
    public IActionResult AzureEvents(AzureWebhookModelEvent<Resource> webhookSubscription)
    {
        return Ok(webhookSubscription);
    }

    /// <summary>
    /// Work item commented on
    /// Work item updated
    /// Work item restored
    /// Work item deleted
    /// Work item created
    /// </summary>
    /// <param name="workItemEvent">Not tested</param>
    /// <returns></returns>
    [HttpPost($"{WebhookEndPoint.AzureWorkItemsEvents}")]
    public async Task<IActionResult> AzureWorkItemsEventsAsync(AzureWebhookModelEvent<WorkItemResource> workItemEvent)
    {
        return Ok(await _mediator.Send(workItemEvent));
    }

    /// <summary>
    /// Code checked in
    /// Code pushed
    /// Pull request created
    /// Pull request merge commit created
    /// Pull request updated
    /// </summary>
    /// <param name="codeEvent">Not tested</param>
    /// <returns></returns>
    [HttpPost($"{WebhookEndPoint.AzureCodeEvents}")]
    public async Task<IActionResult> AzureCodeEvntsAsync(AzureWebhookModelEvent<CodeResource> codeEvent)
    {
        return Ok(await _mediator.Send(codeEvent));
    }

    /// <summary>
    /// Job state changed
    /// Run state changed
    /// Run stage state changed
    /// Run stage waiting for approval
    /// Run stage approval completed
    /// Run job state changed
    /// </summary>
    /// <param name="pipelineEvent">Not tested</param>
    /// <returns></returns>
    [HttpPost($"{WebhookEndPoint.AzurePipelineEventEvnts}")]
    public async Task<IActionResult> AzurePipelineEventEvntsAsync(AzureWebhookModelEvent<PipeLinesResource> pipelineEvent)
    {
        return Ok(await _mediator.Send(pipelineEvent));
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
    /// <param name="buildAndReleaseEvnts">Not tested</param>
    /// <returns></returns>
    [HttpPost($"{WebhookEndPoint.BuildAndReleaseEvents}")]
    public async Task<IActionResult> BuildAndReleaseEvntsAsync(AzureWebhookModelEvent<BuildAndReleaseResource> buildAndReleaseEvnts)
    {
        return Ok(await _mediator.Send(buildAndReleaseEvnts));
    }
}