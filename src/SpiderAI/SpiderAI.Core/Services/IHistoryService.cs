using Microsoft.SemanticKernel.ChatCompletion;

namespace SpiderAI.Core.Services;

public interface IHistoryService
{
    ValueTask<ChatHistory> LoadHistoryAsync(Guid conversationId);
    ValueTask PersistHistoryAsync(Guid conversationId, ChatHistory chatHistory);
}