var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Host.UseSerilog((ctx, cfg) => cfg.ReadFrom.Configuration(ctx.Configuration));
builder.Services.AddAzureDevOpsClients();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapPost("/todoitems", async (IAzureDevOpsClient azureDevOpsClient) =>
{
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

    var wiqlResponses = await azureDevOpsClient.GetWiqlResponses(wiqlRequest);

    return Results.Ok(wiqlResponses.AsT0);
});

app.MapPost("/projects", async (IAzureDevOpsClient azureDevOpsClient) =>
{
    var baseRequest = new BaseRequest
    {
        ApiVersion = "v5",
        Organization = "TunNetCom",
        Project = "Aoin_Time",
        Team = "938eb754-ae25-4088-bf34-c9bf242e966c"
    };

    var res = await azureDevOpsClient.GetAll(baseRequest);

    return Results.Ok(res);
});

app.Run();