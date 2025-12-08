
public abstract class Goal
{
    private string _name;
    private string _description;
    private int _points;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    // Getters
    public string GetName() { return _name; }
    public string GetDescription() { return _description; }
    public int GetPoints() { return _points; }

    // Setters
    public void SetName(string name) { _name = name; }
    public void SetDescription(string desc) { _description = desc; }
    public void SetPoints(int points) { _points = points; }

    // Polymorphic methods
    public abstract int RecordEvent();
    public abstract string GetStatus();
}
