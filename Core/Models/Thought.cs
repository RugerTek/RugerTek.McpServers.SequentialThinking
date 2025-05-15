namespace Core.Models;

public sealed class Thought
{
    public string Content { get; set; }
    public int Index { get; set; }
    public int TotalThoughts { get; set; }
    public List<string> History { get; set; }
    public bool IsValid { get; set; }
    public string Branch { get; set; }

    public Thought(string content, int index, int totalThoughts)
    {
        Content = content;
        Index = index;
        TotalThoughts = totalThoughts;
        History = new List<string>();
        IsValid = true;
        Branch = string.Empty;
    }
}