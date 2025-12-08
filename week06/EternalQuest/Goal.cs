
using System;

public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    public Goal(string shortName, string description, int points)
    {
        _shortName = shortName;
        _description = description;
        _points = points;
    }

    public string ShortName => _shortName;
    public string Description => _description;
    public int Points => _points;

    // Called when the user records an event for the goal.
    // Should return the amount of points awarded by this call (including bonuses).
    public abstract int RecordEvent();

    public abstract bool IsComplete();

    // For display in lists
    public abstract string GetDetailsString();

    // For saving to file (type and data)
    public abstract string GetStringRepresentation();

    // Optional: construct a Goal from string representation in derived classes
}
