using Microsoft.SemanticKernel;

namespace SpiderAI.Core.Chat;
public interface ISimpleChat
{
    IAsyncEnumerable<StreamingChatMessageContent> Respond(string input);
}