namespace AzureDevopsService.Application.Featurs.MessageBroker.Producer.Helper;

public static class ServiceHookEventType
{
    public static readonly IReadOnlyList<string> WorkItem =
    [
        "workitem.created",
        "workitem.updated",
        "workitem.deleted",
        "workitem.restored",
        "workitem.comment.added",
        "workitem.comment.updated",
        "workitem.comment.deleted",
    ];

    public static readonly IReadOnlyList<string> Build =
    [
        "build.complete",
        "build.queued",
        "build.started",
    ];

    public static readonly IReadOnlyList<string> Release =
    [
        "ms.vss-release.release-created-event",
        "ms.vss-release.deployment-approval-completed-event",
        "ms.vss-release.deployment-completed-event",
        "ms.vss-release.release-deploy-phase-changed-event",
    ];

    public static readonly IReadOnlyList<string> Code =
    [
        "git.push",
        "tfvc.checkin",
        "git.pullrequest.created",
        "git.pullrequest.updated",
        "git.pullrequest.merged",
    ];

    public static readonly IReadOnlyList<string> Security =
    [
        "ms.vss-admin.security.namespace-modified",
    ];

    public static readonly IReadOnlyList<string> ServiceHooks =
    [
        "servicehook.subscription.created",
        "servicehook.subscription.deleted",
    ];
}