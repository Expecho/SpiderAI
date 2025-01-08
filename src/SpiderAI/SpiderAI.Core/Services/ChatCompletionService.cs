using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

namespace SpiderAI.Core.Services;

public class ChatCompletionService(Kernel kernel, IHistoryService historyService)
{
    public async IAsyncEnumerable<StreamingChatMessageContent> Respond(string input, string modelName, Guid conversationId)
    {
        var history = await historyService.LoadHistoryAsync(conversationId);
        history.AddUserMessage(input);

        var service = kernel.GetRequiredService<IChatCompletionService>(modelName);

        var contents = service.GetStreamingChatMessageContentsAsync(history);
        await foreach (var content in contents)
        {
            
            yield return content;
        }
        
        await historyService.PersistHistoryAsync(conversationId, history);
    }
}
