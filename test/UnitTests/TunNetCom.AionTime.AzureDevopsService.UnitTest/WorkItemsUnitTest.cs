using Moq;
using Newtonsoft.Json;
using TunNetCom.AionTime.AzureDevopsService.API.Clients;
using TunNetCom.AionTime.AzureDevopsService.API.Clients.WorkItems.Contracts;

namespace TunNetCom.AionTime.AzureDevopsService.UnitTest;

public class WorkItemsUnitTest
{
    [Fact]
    public async Task GetTo10WorkItemFromAnOrganisationAsync()
    {
        // Arrange
        string json = @"{
            ""queryType"": ""flat"",
            ""queryResultType"": ""workItem"",
            ""asOf"": ""2024-05-01T14:44:32.22Z"",
            ""columns"": [
                {
                    ""referenceName"": ""System.Id"",
                    ""name"": ""ID"",
                    ""url"": ""https://dev.azure.com/TunNetCom/_apis/wit/fields/System.Id""
                },
                {
                    ""referenceName"": ""System.Title"",
                    ""name"": ""Title"",
                    ""url"": ""https://dev.azure.com/TunNetCom/_apis/wit/fields/System.Title""
                },
                {
                    ""referenceName"": ""System.State"",
                    ""name"": ""State"",
                    ""url"": ""https://dev.azure.com/TunNetCom/_apis/wit/fields/System.State""
                },
                {
                    ""referenceName"": ""System.IterationPath"",
                    ""name"": ""Iteration Path"",
                    ""url"": ""https://dev.azure.com/TunNetCom/_apis/wit/fields/System.IterationPath""
                }
            ],
            ""workItems"": [
                {
                    ""id"": 3,
                    ""url"": ""https://dev.azure.com/TunNetCom/3348a3bb-788f-42b4-a0ab-ba7210c86b88/_apis/wit/workItems/3""
                },
                {
                    ""id"": 7,
                    ""url"": ""https://dev.azure.com/TunNetCom/3348a3bb-788f-42b4-a0ab-ba7210c86b88/_apis/wit/workItems/7""
                },
                {
                    ""id"": 10,
                    ""url"": ""https://dev.azure.com/TunNetCom/3348a3bb-788f-42b4-a0ab-ba7210c86b88/_apis/wit/workItems/10""
                }
            ]
        }";

        WiqlResponses expectedResponses = JsonConvert.DeserializeObject<WiqlResponses>(json);

        var azureDevOpsClientMock = new Mock<IAzureDevOpsClient>();
        azureDevOpsClientMock.Setup(x => x.GetWiqlResponses(It.IsAny<WiqlRequest>())).ReturnsAsync(expectedResponses);

        // Use your implementation of IAzureDevOpsClient here
        IAzureDevOpsClient azureDevOpsClient = azureDevOpsClientMock.Object;

        var wiqlRequest = new WiqlRequest
        {
            ApiVersion = "v5",
            Organization = "TunNetCom",
            Project = "Aion_Time",
            Team = "938eb754-ae25-4088-bf34-c9bf242e966c",
            Query = @"SELECT [System.Id], [System.Title], [System.State], [System.IterationPath] 
                      FROM workitems WHERE [System.TeamProject] = @project AND [System.WorkItemType] <> '' 
                      AND EVER [System.AssignedTo] = 'Nieze <nieze.benmansour@outlook.fr>'"
        };

        // Act
        var result = await azureDevOpsClient.GetWiqlResponses(wiqlRequest);


        

        // Assert
        Assert.NotNull(result.AsT0);
        Assert.Equal(expectedResponses, result);

    }
}