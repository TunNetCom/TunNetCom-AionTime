namespace TunNetCom.AionTime.AzureDevopsService.UnitTest;

public class WorkItemsUnitTest
{
    [Fact]
    public async Task GetWorkItemsTest()
    {
        var serviceProvider = new ServiceCollection()
            .AddAzureDevOpsClients()
            .BuildServiceProvider();

        var sut = serviceProvider.GetRequiredService<IAzureDevOpsClient>();

        WiqlRequest wiqlRequest = new WiqlRequest
        {
            ApiVersion = "v5",
            Organization = "TunNetCom",
            Project = "Aion_Time",
            Team = "938eb754-ae25-4088-bf34-c9bf242e966c",
            Query = @"SELECT [System.Id], [System.Title], [System.State], [System.IterationPath] 
                      FROM workitems WHERE [System.TeamProject] = @project AND [System.WorkItemType] <> ''",
        };

        var result = await sut.GetWiqlResponses(wiqlRequest);

        result.Should().NotBeNull();

        result.AsT0.Should().NotBeNull();

        if (result.AsT0 is null)
        {
            throw new Exception("WorkItems response was null!");
        }

        result.AsT0.WorkItems.Should()
            .NotBeNull();

        result.AsT0.WorkItems.Count.Should().BePositive();
    }
}