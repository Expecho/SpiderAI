using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpiderAI.Core.Configuration;
using SpiderAI.Core.SemanticKernel;
using SpiderAI.Core.Services;

namespace SpiderAI.Core;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSpiderAI(this IServiceCollection services, IConfiguration configuration)
    {
        var azureOpenAi = new AzureOpenAI();
        configuration.GetSection(nameof(AzureOpenAI)).Bind(azureOpenAi);

        services.AddKernel().AddAzureOpenAI(azureOpenAi);
        services.AddSingleton<ChatCompletionService>();
        services.AddSingleton<TextToImageService>();
        services.AddSingleton<IHistoryService, InMemoryHistoryService>();

        return services;
    }
}


