namespace AzureDevopsService.Application.Featurs.MessageBroker.Producer.Helper;

public static class ServiceHookEventType
{
    public static readonly IReadOnlyList<string> WorkItem =
    [
        AzureWebhookEventTypes.WorkItemCreated,
        AzureWebhookEventTypes.WorkItemUpdated,
        AzureWebhookEventTypes.WorkItemDeleted,
        AzureWebhookEventTypes.WorkItemRestored,
        AzureWebhookEventTypes.WorkItemCommentAdded,
        AzureWebhookEventTypes.WorkItemCommentUpdated,
        AzureWebhookEventTypes.WorkItemCommentDeleted,
    ];

    public static readonly IReadOnlyList<string> Build =
    [
        AzureWebhookEventTypes.BuildComplete,
        AzureWebhookEventTypes.BuildQueued,
        AzureWebhookEventTypes.BuildStarted,
    ];

    public static readonly IReadOnlyList<string> Release =
    [
        AzureWebhookEventTypes.ReleaseCreated,
        AzureWebhookEventTypes.DeploymentApprovalCompleted,
        AzureWebhookEventTypes.DeploymentCompleted,
        AzureWebhookEventTypes.ReleaseDeployPhaseChanged,
    ];

    public static readonly IReadOnlyList<string> Code =
    [
        AzureWebhookEventTypes.GitPush,
        AzureWebhookEventTypes.GitPullRequestCreated,
        AzureWebhookEventTypes.GitPullRequestUpdated,
        AzureWebhookEventTypes.GitPullRequestMerged,
        AzureWebhookEventTypes.GitPullRequestReviewerUpdated,
        AzureWebhookEventTypes.GitPullRequestVoteUpdated,
        AzureWebhookEventTypes.GitPullRequestMergeCommitCreated,
        AzureWebhookEventTypes.GitPullRequestBranchUpdated,
        AzureWebhookEventTypes.GitRepositoryCreated,
        AzureWebhookEventTypes.GitRepositoryDeleted,
        AzureWebhookEventTypes.GitRepositoryModified,
        AzureWebhookEventTypes.GitBranchCreated,
        AzureWebhookEventTypes.GitBranchDeleted,
        AzureWebhookEventTypes.GitTagCreated,
        AzureWebhookEventTypes.GitTagDeleted,
        AzureWebhookEventTypes.TfvcCheckin,
        AzureWebhookEventTypes.TfvcShelvesetCreated,
        AzureWebhookEventTypes.TfvcShelvesetUpdated,
        AzureWebhookEventTypes.TfvcShelvesetDeleted,
    ];

    public static readonly IReadOnlyList<string> Pipeline =
    [
        AzureWebhookEventTypes.PipelineRunQueued,
        AzureWebhookEventTypes.PipelineRunStarted,
        AzureWebhookEventTypes.PipelineRunCompleted,
        AzureWebhookEventTypes.PipelineRunStageStarted,
        AzureWebhookEventTypes.PipelineRunStageCompleted,
        AzureWebhookEventTypes.PipelineRunJobStarted,
        AzureWebhookEventTypes.PipelineRunJobCompleted,
        AzureWebhookEventTypes.PipelineRunPhaseStarted,
        AzureWebhookEventTypes.PipelineRunPhaseCompleted,
    ];
}