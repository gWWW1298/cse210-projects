
public class ChecklistGoal : Goal
{
    private int _target;
    private int _count;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _count = 0;
    }

    public override int RecordEvent()
    {
        _count++;

        if (_count == _target)
        {
            return GetPoints() + _bonus;
        }

        return GetPoints();
    }

    public override string GetStatus()
    {
        return $"[{_count}/{_target}]";
    }
}
