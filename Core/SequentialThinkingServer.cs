using System.Collections.Concurrent;
using Core.Models;

namespace Core;

public sealed class SequentialThinkingServer()
{
    private readonly List<ThoughtData> _thoughtHistory = [];
    private readonly ConcurrentDictionary<string, List<ThoughtData>> _branches = [];

    public ProcessThoughtResponse ProcessThought(ProcessThoughtRequest content)
    {
        // Validate the input
        var validatedInput = ValidateThought(content);

        // Adjust totalThoughts if Thought Number exceeds it
        if (validatedInput.ThoughtNumber > validatedInput.TotalThoughts)
        {
            validatedInput.TotalThoughts = validatedInput.ThoughtNumber;
        }

        // Add to thought history
        _thoughtHistory.Add(validatedInput);

        // Handle branching logic
        if (validatedInput.BranchFromThought.HasValue && !string.IsNullOrEmpty(validatedInput.BranchId))
        {
            if (!_branches.ContainsKey(validatedInput.BranchId))
            {
                _branches[validatedInput.BranchId] = new List<ThoughtData>();
            }
            _branches[validatedInput.BranchId].Add(validatedInput);
        }

        // Format the thought
        var formattedThought = FormatThought(validatedInput);
        // Console.Error.WriteLine(formattedThought);

        // Return the result
        return new ProcessThoughtResponse
        {
            Thought = formattedThought,
            ThoughtNumber = validatedInput.ThoughtNumber,
            TotalThoughts = validatedInput.TotalThoughts,
            NextThoughtNeeded = validatedInput.NextThoughtNeeded,
            Branches = _branches.Keys.ToList(),
            ThoughtHistoryLength = _thoughtHistory.Count
        };
    }
    
    private ThoughtData ValidateThought(ProcessThoughtRequest input)
    {
        // Add validation here
        
        return new ThoughtData
        {
            Thought = input.Thought,
            ThoughtNumber = input.ThoughtNumber,
            TotalThoughts = input.TotalThoughts,
            NextThoughtNeeded = input.NextThoughtNeeded,
            IsRevision = input.IsRevision,
            RevisesThought = input.RevisesThought,
            BranchFromThought = input.BranchFromThought,
            BranchId = input.BranchId,
            NeedsMoreThoughts = input.NeedsMoreThoughts
        };
    }

    private string FormatThought(ThoughtData thoughtData)
    {
        var thoughtNumber = thoughtData.ThoughtNumber;
        var totalThoughts = thoughtData.TotalThoughts;
        var thought = thoughtData.Thought;
        var isRevision = thoughtData.IsRevision;
        var revisesThought = thoughtData.RevisesThought;
        var branchFromThought = thoughtData.BranchFromThought;
        var branchId = thoughtData.BranchId;

        var prefix = string.Empty;
        var context = string.Empty;

        if (isRevision == true)
        {
            prefix = "🔄 Revision"; // Replace chalk with plain text or a library for colored console output if needed.
            context = $" (revising thought {revisesThought})";
        }
        else if (branchFromThought.HasValue)
        {
            prefix = "🌿 Branch";
            context = $" (from thought {branchFromThought}, ID: {branchId})";
        }
        else
        {
            prefix = "💭 Thought";
            context = string.Empty;
        }

        var header = $"{prefix} {thoughtNumber}/{totalThoughts}{context}";
        var borderLength = Math.Max(header.Length, thought.Length) + 4;
        var border = new string('─', borderLength);

        return $" ┌{border}┐\n │ {header} │\n ├{border}┤\n │ {thought.PadRight(border.Length - 2)} │\n └{border}┘";
    }
}