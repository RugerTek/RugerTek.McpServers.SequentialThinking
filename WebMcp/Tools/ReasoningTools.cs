using System.ComponentModel;
using Core;
using ModelContextProtocol.Protocol;
using ModelContextProtocol.Server;
using RugerTek.McpServers.SequentialThinking.Contracts;

namespace RugerTek.McpServers.SequentialThinking.Tools;

[McpServerToolType]
public sealed class ReasoningTools
{
    [McpServerTool, Description("")]
    public static Task<> ProcessThought(SequentialThinkingServerSessions sessions, string sessionId, ProcessThoughtRequest request)
    {
        var server = sessions.GetSession(sessionId);
        
        server.ProcessThought(request);
        
        return Task.CompletedTask;
    }
}