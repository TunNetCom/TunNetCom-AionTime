using Microsoft.Extensions.Configuration;
using TunNetCom.AionTime.AzureDevopsService.Contracts.AzureRequestResourceModel;
using TunNetCom.AionTime.AzureDevopsService.Contracts.AzureResponceModel;

namespace TunNetCom.AionTime.AzureDevopsService.UnitTest;

public class WorkItemsUnitTest
{
    // [Fact]
    // public async Task GetWorkItemsTest()
    // {
    //    // .AddAzureDevOpsClients()
    //    ServiceProvider serviceProvider = new ServiceCollection()
    //        .BuildServiceProvider();

    // IAzureDevOpsClient azureDevOpsClient = serviceProvider.GetRequiredService<IAzureDevOpsClient>();

    // WiqlRequest wiqlRequest = new()
    //    {
    //        ApiVersion = "v5",
    //        Organization = "TunNetCom",
    //        Project = "Aion_Time",
    //        Team = "938eb754-ae25-4088-bf34-c9bf242e966c",
    //        Query = @"SELECT [System.Id], [System.Title], [System.State], [System.IterationPath]
    //                  FROM workitems WHERE [System.TeamProject] = @project AND [System.WorkItemType] <> ''",
    //    };

    // OneOf<WiqlResponses?, WiqlBadRequest?> getWiqlResponses
    //        = await azureDevOpsClient.GetWiqlResponses(wiqlRequest);

    // _ = getWiqlResponses.Should().NotBeNull();

    // _ = getWiqlResponses.AsT0.Should().NotBeNull();

    // if (getWiqlResponses.AsT0 is null)
    //    {
    //        return;
    //    }

    // _ = getWiqlResponses.AsT0.WorkItems.Should()
    //        .NotBeNull();

    // _ = getWiqlResponses.AsT0.WorkItems.Count().Should().BePositive();
    // }
}