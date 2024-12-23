var builder = DistributedApplication.CreateBuilder(args);

var backendApi = builder.AddProject<Projects.SpiderAI_Server>("spiderai-server");

builder
    .AddNpmApp("spiderai-client", "../SpiderAI.Client")
    .WithReference(backendApi)
    .WithHttpEndpoint(targetPort: 56779)
    .WaitFor(backendApi);

builder.Build().Run();
