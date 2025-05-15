namespace Core.Models;

public sealed class ThoughtData
{
    public string Thought { get; set; } = string.Empty;
    public int ThoughtNumber { get; set; }
    public int TotalThoughts { get; set; }
    public bool NextThoughtNeeded { get; set; }
    public bool? IsRevision { get; set; }
    public int? RevisesThought { get; set; }
    public int? BranchFromThought { get; set; }
    public string BranchId { get; set; } = string.Empty;
    public bool? NeedsMoreThoughts { get; set; }
}