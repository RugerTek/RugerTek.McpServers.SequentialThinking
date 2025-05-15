using System.Collections.Concurrent;

namespace Core;

public sealed class SequentialThinkingServerSessions
{
    private ConcurrentDictionary<string, SequentialThinkingServer> Sessions { get; } = new();

    public SequentialThinkingServer GetSession(string sessionId)
    {
        // concurrently get the session for the id
        return Sessions.GetOrAdd(sessionId, _ => new SequentialThinkingServer());
    }
    
    public void RemoveSession(string sessionId)
    {
        Sessions.TryRemove(sessionId, out _);
    }
    
    public void ClearSessions()
    {
        Sessions.Clear();
    }
    
    public int Count => Sessions.Count;
    
    public bool Contains(string sessionId)
    {
        return Sessions.ContainsKey(sessionId);
    }
    
    public bool TryGetValue(string sessionId, out SequentialThinkingServer? session)
    {
        return Sessions.TryGetValue(sessionId, out session);
    }
    
    public IEnumerable<SequentialThinkingServer> GetAllSessions()
    {
        return Sessions.Values;
    }
    
    public void AddSession(string sessionId, SequentialThinkingServer session)
    {
        Sessions.TryAdd(sessionId, session);
    }
    
    public void UpdateSession(string sessionId, SequentialThinkingServer session)
    {
        Sessions[sessionId] = session;
    }
}