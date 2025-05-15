using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Core.Models;

public sealed class ProcessThoughtRequest
{
    [Required, Description("Your current thinking step")] public string Thought { get; set; } = string.Empty;
    [Required, Description("Whether another thought step is needed")] public bool NextThoughtNeeded { get; set; }
    [Required, Description("Current thought number")] public int ThoughtNumber { get; set; }
    [Required, Description("Estimated total thoughts needed")] public int TotalThoughts { get; set; }
    [Description("Whether this revises previous thinking")] public bool IsRevision { get; set; }
    [Description("Which thought is being reconsidered")] public int RevisesThought { get; set; }
    [Description("Branching point thought number")] public int BranchFromThought { get; set; }
    [Description("Branch identifie")] public string BranchId { get; set; } = string.Empty;
    [Description("If more thoughts are needed")] public bool NeedsMoreThoughts { get; set; }
    
}