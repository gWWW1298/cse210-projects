
public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        // Eternal goals give points every time
        return GetPoints();
    }

    public override string GetStatus()
    {
        return "[∞]";
    }
}
