# Spider AI

Spider AI showcases what is possible using LLMs using .Net. It is build using

- [Semantic Kernel](https://learn.microsoft.com/en-us/semantic-kernel/overview/)
- [.Net Aspire](https://learn.microsoft.com/en-us/dotnet/aspire/get-started/aspire-overview)
- [Open Telemetry](https://opentelemetry.io/)

## Features

- Support for [Azure OpenAI](https://learn.microsoft.com/en-us/azure/ai-services/openai/overview)

## Getting Started

### Server Configuration

In the server project, add the following configuration to the [user secrets](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-9.0&tabs=windows#secret-manager). Replace the values with your own.

```json
"AzureOpenAI": {
  "Endpoint": "https://xxx.openai.azure.com/",
  "ApiKey": "xxx",
  "Models": [
    {
      "ModelId": "xxx",
      "Capability": "Chat"
    },
    {
      "ModelId": "yyy",
      "Capability": "TextEmbedding"
    },
    {
      "ModelId": "zzz",
      "Capability": "ImageGeneration"
    }
  ]
}
```
