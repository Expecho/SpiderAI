using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

namespace SpiderAI.Core.Chat;

public class SimpleChat(Kernel kernel) : ISimpleChat
{
    private readonly IChatCompletionService service = kernel.GetRequiredService<IChatCompletionService>();

    public IAsyncEnumerable<StreamingChatMessageContent> Respond(string input)
    {
        return service.GetStreamingChatMessageContentsAsync(input);
    }
}
