using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.TextToImage;

namespace SpiderAI.Core.Services;

public class TextToImageService(Kernel kernel, IHistoryService historyService, IHttpClientFactory httpClientFactory)
{
    public async Task<IReadOnlyList<ImageContent>> Respond(string input, string modelName, Guid conversationId)
    {
        var history = await historyService.LoadHistoryAsync(conversationId);
        history.AddUserMessage(input);

        var service = kernel.GetRequiredService<ITextToImageService>(modelName);
        var content = await service.GetImageContentsAsync(input);

        foreach (var imageContent in content)
        {
            imageContent.Data = await EnrichImageContentAsync(imageContent);
            //var content = new ChatMessageContentItemCollection();
            //k.Add(new ImageContent(imageContent));
            //history.AddMessage(AuthorRole.Assistant, imageContent.Data);
        }

        return content;
    }

    private async ValueTask<ReadOnlyMemory<Byte>?> EnrichImageContentAsync(ImageContent imageContent)
    {
        var uri = imageContent.DataUri ?? imageContent.Uri?.ToString();
        if (imageContent.Data == null && uri != null)
        {
            imageContent.Data = await httpClientFactory.CreateClient().GetByteArrayAsync(uri);
        }

        return imageContent.Data;
    }
}
