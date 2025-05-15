namespace Core.Models;

public sealed class ProcessThoughtResponse
{
    public string Thought { get; set; } = string.Empty;
    public bool NextThoughtNeeded { get; set; }
    public int ThoughtNumber { get; set; }
    public int TotalThoughts { get; set; }
    public int ThoughtHistoryLength { get; set; }
    public List<string> Branches { get; set; } = [];


}