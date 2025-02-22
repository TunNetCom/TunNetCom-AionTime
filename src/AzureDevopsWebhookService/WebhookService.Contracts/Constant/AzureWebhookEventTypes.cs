namespace WebhookService.Contracts.Constant;

public static class AzureWebhookEventTypes
{
    public const string WorkItemCreated = "workitem.created";
    public const string WorkItemUpdated = "workitem.updated";
    public const string WorkItemDeleted = "workitem.deleted";
    public const string WorkItemRestored = "workitem.restored";
    public const string WorkItemCommentAdded = "workitem.comment.added";
    public const string WorkItemCommentUpdated = "workitem.comment.updated";
    public const string WorkItemCommentDeleted = "workitem.comment.deleted";

    // Build Events
    public const string BuildComplete = "build.complete";
    public const string BuildQueued = "build.queued";
    public const string BuildStarted = "build.started";

    // Release Events
    public const string ReleaseCreated = "ms.vss-release.release-created-event";
    public const string DeploymentApprovalCompleted = "ms.vss-release.deployment-approval-completed-event";
    public const string DeploymentCompleted = "ms.vss-release.deployment-completed-event";
    public const string ReleaseDeployPhaseChanged = "ms.vss-release.release-deploy-phase-changed-event";

    // Git Events
    public const string GitPush = "git.push";
    public const string GitPullRequestCreated = "git.pullrequest.created";
    public const string GitPullRequestUpdated = "git.pullrequest.updated";
    public const string GitPullRequestMerged = "git.pullrequest.merged";
    public const string GitPullRequestCommentEvent = "git.pullrequest.comment";
    public const string GitPullRequestReviewerUpdated = "git.pullrequest.reviewer.updated";
    public const string GitPullRequestVoteUpdated = "git.pullrequest.vote.updated";
    public const string GitPullRequestMergeCommitCreated = "git.pullrequest.mergecommit.created";
    public const string GitPullRequestBranchUpdated = "git.pullrequest.branch.updated";
    public const string GitRepositoryCreated = "git.repository.created";
    public const string GitRepositoryDeleted = "git.repository.deleted";
    public const string GitRepositoryModified = "git.repository.modified";
    public const string GitBranchCreated = "git.branch.created";
    public const string GitBranchDeleted = "git.branch.deleted";
    public const string GitTagCreated = "git.tag.created";
    public const string GitTagDeleted = "git.tag.deleted";

    // TFVC Events
    public const string TfvcCheckin = "tfvc.checkin";
    public const string TfvcShelvesetCreated = "tfvc.shelveset.created";
    public const string TfvcShelvesetUpdated = "tfvc.shelveset.updated";
    public const string TfvcShelvesetDeleted = "tfvc.shelveset.deleted";

    // Security Events
    public const string SecurityNamespaceModified = "ms.vss-admin.security.namespace-modified";

    // Service Hook Subscription Events
    public const string ServiceHookSubscriptionCreated = "servicehook.subscription.created";
    public const string ServiceHookSubscriptionDeleted = "servicehook.subscription.deleted";
    public const string ServiceHookSubscriptionUpdated = "servicehook.subscription.updated";

    // Pipeline Events
    public const string PipelineRunQueued = "pipeline.run.queued";
    public const string PipelineRunStarted = "pipeline.run.started";
    public const string PipelineRunCompleted = "pipeline.run.completed";
    public const string PipelineRunStageStarted = "pipeline.run.stage.started";
    public const string PipelineRunStageCompleted = "pipeline.run.stage.completed";
    public const string PipelineRunJobStarted = "pipeline.run.job.started";
    public const string PipelineRunJobCompleted = "pipeline.run.job.completed";
    public const string PipelineRunPhaseStarted = "pipeline.run.phase.started";
    public const string PipelineRunPhaseCompleted = "pipeline.run.phase.completed";

    // Check Events
    public const string CheckPending = "check.pending";
    public const string CheckCompleted = "check.completed";
    public const string CheckUpdated = "check.updated";
}