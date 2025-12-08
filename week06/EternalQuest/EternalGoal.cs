
using System;

public class EternalGoal : Goal
{
    // eternal goals never complete, each RecordEvent gives points
    public EternalGoal(string shortName, string description, int points)
        : base(shortName, description, points)
    {
    }

    public override int RecordEvent()
    {
        Console.WriteLine($"EternalGoal recorded! You earned {_points} points.");
        return _points;
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetDetailsString()
    {
        return $"[∞] {_shortName} ({_description}) - {_points} pts each time";
    }

    public override string GetStringRepresentation()
    {
        // Format: EternalGoal|shortName|description|points
        return $"EternalGoal|{Escape(_shortName)}|{Escape(_description)}|{_points}";
    }

    private string Escape(string s) => s.Replace("|", "/|");
    public static EternalGoal Parse(string[] parts)
    {
        string name = parts[1].Replace("/|", "|");
        string desc = parts[2].Replace("/|", "|");
        int pts = int.Parse(parts[3]);
        return new EternalGoal(name, desc, pts);
    }
}
