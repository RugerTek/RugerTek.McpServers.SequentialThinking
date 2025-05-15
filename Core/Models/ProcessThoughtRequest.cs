namespace RugerTek.McpServers.SequentialThinking.Contracts;

public sealed class ProcessThoughtRequest
{
    public string Thought { get; set; } = string.Empty;
    public bool NextThoughtNeeded { get; set; }
    public int ThoughtNumber { get; set; }
    public int TotalThoughts { get; set; }
    public int IsRevision { get; set; }
    public int RevisesThought { get; set; }
    public int BranchFromThought { get; set; }
    public string BranchId { get; set; } = string.Empty;
    public bool NeedsMoreThoughts { get; set; }
    
}