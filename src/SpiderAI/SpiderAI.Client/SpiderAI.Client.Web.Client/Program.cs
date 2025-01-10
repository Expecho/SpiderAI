using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using SpiderAI.Client.Shared.Services;
using SpiderAI.Client.Web.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Add device-specific services used by the SpiderAI.Client.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();
builder.Services.AddRadzenComponents();

await builder.Build().RunAsync();
