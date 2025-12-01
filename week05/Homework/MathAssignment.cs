
public class MathAssignment : Assignment
{
    private string _textbookSection;
    private string _problems;

    public MathAssignment(string name, string topic, string tbSection, string problems) : base(name, topic)
    {
        SetStudentName(name);
        SetTopic(topic);
        _textbookSection = tbSection;
        _problems = problems;
    }

    public string GetHomeworkList()
    {
        return GetStudentName()+" - "+GetTopic()+"\n"+_textbookSection+" "+_problems ;
    }


}