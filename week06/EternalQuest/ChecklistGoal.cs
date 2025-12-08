
using System;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string shortName, string description, int points, int target, int bonus)
        : base(shortName, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
    }

    public override int RecordEvent()
    {
        if (IsComplete())
        {
            Console.WriteLine("Checklist already completed. No points awarded.");
            return 0;
        }

        _amountCompleted++;
        if (_amountCompleted >= _target)
        {
            Console.WriteLine($"Checklist goal completed! You earned {_points} points plus bonus {_bonus} points.");
            return _points + _bonus;
        }
        else
        {
            Console.WriteLine($"Progress saved! You earned {_points} points. ({_amountCompleted}/{_target})");
            return _points;
        }
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        string box = IsComplete() ? "[X]" : "[ ]";
        return $"{box} {_shortName} ({_description}) - {_points} pts each, Completed {_amountCompleted}/{_target} (bonus {_bonus} on completion)";
    }

    public override string GetStringRepresentation()
    {
        // Format: ChecklistGoal|shortName|description|points|target|bonus|amountCompleted
        return $"ChecklistGoal|{Escape(_shortName)}|{Escape(_description)}|{_points}|{_target}|{_bonus}|{_amountCompleted}";
    }

    private string Escape(string s) => s.Replace("|", "/|");
    public static ChecklistGoal Parse(string[] parts)
    {
        // type, name, desc, points, target, bonus, amountCompleted
        string name = parts[1].Replace("/|", "|");
        string desc = parts[2].Replace("/|", "|");
        int pts = int.Parse(parts[3]);
        int target = int.Parse(parts[4]);
        int bonus = int.Parse(parts[5]);
        int amount = int.Parse(parts[6]);
        ChecklistGoal g = new ChecklistGoal(name, desc, pts, target, bonus);
        typeof(ChecklistGoal).GetField("_amountCompleted", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(g, amount);
        return g;
    }
}
