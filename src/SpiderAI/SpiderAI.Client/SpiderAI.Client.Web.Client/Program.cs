using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SpiderAI.Client.Shared.Services;
using SpiderAI.Client.Web.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Add device-specific services used by the SpiderAI.Client.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();

await builder.Build().RunAsync();
