WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Host.UseSerilog((ctx, cfg) => cfg.ReadFrom.Configuration(ctx.Configuration));
builder.Services.AddAzureDevOpsClients();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/wiql", async (IAzureDevOpsClient azureDevOpsClient) =>
{
    WiqlRequest wiqlRequest = new()
    {
        ApiVersion = "v5",
        Organization = "TunNetCom",
        Project = "Aion_Time",
        Team = "938eb754-ae25-4088-bf34-c9bf242e966c",
        Query = @"SELECT [System.Id], [System.Title], [System.State], [System.IterationPath] 
                    FROM workitems WHERE [System.TeamProject] = @project AND [System.WorkItemType] <> '' 
                    AND EVER [System.AssignedTo] = 'Nieze <nieze.benmansour@outlook.fr>'",
    };

    OneOf<WiqlResponses?, WiqlBadRequest?> wiqlResponses = await azureDevOpsClient.GetWiqlResponses(wiqlRequest);

    return Results.Ok(wiqlResponses.AsT0);
});

app.MapPost("/projects", async (IAzureDevOpsClient azureDevOpsClient) =>
{
    BaseRequest baseRequest = new()
    {
        ApiVersion = "v5",
        Organization = "TunNetCom",
        Project = "Aoin_Time",
        Team = "938eb754-ae25-4088-bf34-c9bf242e966c",
    };

    GetAllProjectsResponse? getAllProjectsResponse = await azureDevOpsClient.GetAll(baseRequest);

    return Results.Ok(getAllProjectsResponse);
});

app.Run();