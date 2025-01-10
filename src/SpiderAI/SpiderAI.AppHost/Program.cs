var builder = DistributedApplication.CreateBuilder(args);

var server = builder.AddProject<Projects.SpiderAI_Server>("spiderai-server");
builder.AddProject<Projects.SpiderAI_Client_Web>("spiderai-webclient")
    .WithEnvironment("Server_Host", server.GetEndpoint("http"));

builder.Build().Run();
