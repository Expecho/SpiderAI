var builder = DistributedApplication.CreateBuilder(args);

var backendApi = builder.AddProject<Projects.SpiderAI_Server>("spiderai-server");

builder.Build().Run();
