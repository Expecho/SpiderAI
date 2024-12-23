using SpiderAI.Core;
using SpiderAI.Core.Chat;
using SpiderAI.ServiceDefaults;

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

app.MapGet("/api/chat", (ISimpleChat chat, string message) =>
{
    return chat.Respond("Write an essay about nuclear energy");
})
.WithName("chat");

app.Run();