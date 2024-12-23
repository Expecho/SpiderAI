using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpiderAI.Core.Chat;
using SpiderAI.Core.Configuration;
using SpiderAI.Core.SemanticKernel;

namespace SpiderAI.Core;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSpiderAI(this IServiceCollection services, IConfiguration configuration)
    {
        var azureOpenAi = new AzureOpenAI();
        configuration.GetSection(nameof(AzureOpenAI)).Bind(azureOpenAi);

        services.AddKernel().AddAzureOpenAI(azureOpenAi);
        services.AddTransient<ISimpleChat, SimpleChat>();

        return services;
    }
}


