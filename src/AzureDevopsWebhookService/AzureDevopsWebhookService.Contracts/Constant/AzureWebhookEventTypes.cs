using TunNetCom.AionTime.AzureDevops.WebhookService.Contracts.Constant;

namespace TunNetCom.AionTime.AzureDevops.WebhookService.Contracts.Constant;

public static class AzureWebhookEventTypes
{
    public const string WorkitemCreated = "workitem.created";

    public const string WorkitemCommented = "workitem.commented";

    public const string WorkitemUpdated = "workitem.updated";

    public const string WorkitemRestored = "workitem.restored";

    public const string WorkitemDeleted = "workitem.deleted";

    public const string GitPullrequestUpdated = "git.pullrequest.updated";

    public const string GitPullrequestMerged = "git.pullrequest.merged";

    public const string GitPullrequestCreated = "git.pullrequest.created";

    public const string GitPush = "git.push";

    public const string TfvcCheckin = "tfvc.checkin";

    public const string RunJobStateChanged = "ms.vss-pipelines.job-state-changed-event";

    public const string RunStageApprovalCompleted = "ms.vss-pipelinechecks-events.approval-completed";

    public const string RunStageWaitingForApproval = "ms.vss-pipelinechecks-events.approval-pending";

    public const string RunStageStateChanged = "ms.vss-pipelines.stage-state-changed-event";

    public const string RunStateChanged = "ms.vss-pipelines.run-state-changed-event";

    public const string JobStateChanged = "ms.vss-pipelines.job-state-changed-event";

    public const string ReleaseDeploymentStarted = "ms.vss-release.deployment-started-event";

    public const string ReleaseDeploymentCompleted = "ms.vss-release.deployment-completed-event";

    public const string ReleaseDeploymentApprovalPending = "ms.vss-release.deployment-approval-pending-event";

    public const string ReleaseDeploymentApprovalCompleted = "ms.vss-release.deployment-approval-completed-event";

    public const string ReleaseCreated = "ms.vss-release.release-created-event";

    public const string ReleaseAbandoned = "ms.vss-release.release-abandoned-event";

    public const string BuildCompleted = "build.complete";
}