using SpiderAI.Core;
using SpiderAI.Core.Services;
using SpiderAI.ServiceDefaults;

AppContext.SetSwitch("Microsoft.SemanticKernel.Experimental.GenAI.EnableOTelDiagnostics", true);

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSpiderAI(builder.Configuration);

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddCors(options =>
    {
        options.AddPolicy(name: "localhostCorsPolicy",
                          policy =>
                          {
                              policy.AllowAnyOrigin()
                                    .AllowAnyHeader()
                                    .AllowAnyMethod();
                          });
    });
}

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors("localhostCorsPolicy");
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/api/chat", (ChatCompletionService chat, string message, Guid conversationId) =>
{
    return chat.Respond(message, "azgpt4o", conversationId);
});

app.MapGet("/api/image", (TextToImageService chat, string message, Guid conversationId) =>
{
    return chat.Respond(message, "azdalle3", conversationId);
});

app.Run();