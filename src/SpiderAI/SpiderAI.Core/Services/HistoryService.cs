using Microsoft.SemanticKernel.ChatCompletion;

namespace SpiderAI.Core.Services;

public class InMemoryHistoryService : IHistoryService
{
    private readonly Dictionary<Guid, ChatHistory> _histories = new();

    public ValueTask<ChatHistory> LoadHistoryAsync(Guid conversationId)
    {
        return ValueTask.FromResult(_histories.GetValueOrDefault(conversationId, []));
    }

    public ValueTask PersistHistoryAsync(Guid conversationId, ChatHistory chatHistory)
    {
        _histories[conversationId] = chatHistory;

        return ValueTask.CompletedTask;
    }
}
