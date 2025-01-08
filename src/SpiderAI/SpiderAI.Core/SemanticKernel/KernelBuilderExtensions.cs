using Microsoft.SemanticKernel;
using SpiderAI.Core.Configuration;

namespace SpiderAI.Core.SemanticKernel;

public static class KernelBuilderExtensions
{
    public static IKernelBuilder AddAzureOpenAI(this IKernelBuilder kernelBuilder, AzureOpenAI azureOpenAI)
    {
        foreach (var model in azureOpenAI.Models)
        {
            _ = model.Capability switch
            {
                "ChatCompletion" => kernelBuilder.AddAzureOpenAIChatCompletion(model.ModelId, azureOpenAI.Endpoint, azureOpenAI.ApiKey, serviceId: model.Name),
                "ImageGeneration" => kernelBuilder.AddAzureOpenAITextToImage(model.ModelId, azureOpenAI.Endpoint, azureOpenAI.ApiKey, serviceId: model.Name),
                "TextEmbedding" => kernelBuilder.AddAzureOpenAITextEmbeddingGeneration(model.ModelId, azureOpenAI.Endpoint, azureOpenAI.ApiKey, serviceId: model.Name),
                _ => throw new NotSupportedException($"Model capability '{model.Capability}' is not supported.")
            };
        }

        return kernelBuilder;
    }
}
