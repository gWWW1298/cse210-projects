
using System;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string shortName, string description, int points)
        : base(shortName, description, points)
    {
        _isComplete = false;
    }

    public override int RecordEvent()
    {
        if (_isComplete)
        {
            Console.WriteLine("This goal is already complete. No points awarded.");
            return 0;
        }
        _isComplete = true;
        Console.WriteLine($"SimpleGoal completed! You earned {_points} points.");
        return _points;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetDetailsString()
    {
        string box = _isComplete ? "[X]" : "[ ]";
        return $"{box} {_shortName} ({_description}) - {_points} pts";
    }

    public override string GetStringRepresentation()
    {
        // Format: SimpleGoal|shortName|description|points|isComplete
        return $"SimpleGoal|{Escape(_shortName)}|{Escape(_description)}|{_points}|{_isComplete}";
    }

    private string Escape(string s) => s.Replace("|", "/|");
    public static SimpleGoal Parse(string[] parts)
    {
        // parts expected: type, shortName, description, points, isComplete
        string name = parts[1].Replace("/|", "|");
        string desc = parts[2].Replace("/|", "|");
        int pts = int.Parse(parts[3]);
        bool complete = bool.Parse(parts[4]);
        SimpleGoal g = new SimpleGoal(name, desc, pts);
        if (complete) g.RecordEvent(); // mark complete (gives no points here)
        // ensure we don't duplicate points: better assign private var:
        if (complete) typeof(SimpleGoal).GetField("_isComplete", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(g, true);
        return g;
    }
}
