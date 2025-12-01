
public class WritingAssignment : Assignment
{
    private string _title;
    private string _dueDate;

    public WritingAssignment(string name, string topic, string title) : base(name, topic)
    {
        SetStudentName(name);
        SetTopic(topic);
        _title = title;
    }

    public string GetWritingInfo()
    {
        return GetStudentName() + " - " + GetTopic() + "\n" + _title + " by " + GetStudentName();
    }
}