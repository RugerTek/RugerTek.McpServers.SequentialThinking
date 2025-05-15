using Core.Models;
using RugerTek.McpServers.SequentialThinking.Contracts;

namespace Core;

public sealed class SequentialThinkingServer
{
    private readonly List<Thought> _thoughtHistory;
    private readonly int _totalThoughts;

    public SequentialThinkingServer(int totalThoughts)
    {
        _totalThoughts = totalThoughts;
        _thoughtHistory = new List<Thought>();
    }

    public void ProcessThought(ProcessThoughtRequest content)
    {
        var index = _thoughtHistory.Count + 1;
        var newThought = new Thought(content.Thought, index, _totalThoughts);

        if (ValidateThought(newThought))
        {
            _thoughtHistory.Add(newThought);
            Console.WriteLine($"Thought {index}/{_totalThoughts} added: {content}");
        }
        else
        {
            Console.WriteLine("Invalid thought format.");
        }
    }
    
    public void AddThought(string content)
    {
        var index = _thoughtHistory.Count + 1;
        var newThought = new Thought(content, index, _totalThoughts);

        if (ValidateThought(newThought))
        {
            _thoughtHistory.Add(newThought);
            Console.WriteLine($"Thought {index}/{_totalThoughts} added: {content}");
        }
        else
        {
            Console.WriteLine("Invalid thought format.");
        }
    }

    private bool ValidateThought(Thought thought)
    {
        // Example validation logic
        return !string.IsNullOrWhiteSpace(thought.Content);
    }

    public void BranchThought(int index, string branchContent)
    {
        if (index <= 0 || index > _thoughtHistory.Count)
        {
            Console.WriteLine("Invalid thought index for branching.");
            return;
        }

        var originalThought = _thoughtHistory[index - 1];
        var branchedThought = new Thought(branchContent, originalThought.Index, originalThought.TotalThoughts)
        {
            Branch = $"Branch from Thought {index}"
        };

        _thoughtHistory.Add(branchedThought);
        Console.WriteLine($"Branched thought added: {branchContent}");
    }

    public void DisplayThoughtHistory()
    {
        Console.WriteLine("Thought History:");
        foreach (var thought in _thoughtHistory)
        {
            Console.WriteLine($"Index: {thought.Index}, Content: {thought.Content}, Branch: {thought.Branch}");
        }
    }
}