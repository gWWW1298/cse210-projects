public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity()
    {
        _name = "Activity";
        _description = "This is an Activity";
        _duration = 30; // valeur par défaut
    }

    public void SetActivity(string name, string description, int duration)
    {
        _name = name;
        _description = description;
        _duration = duration;
    }

    public int GetDuration()
    {
        Console.Write("\nHow long, in seconds, would you like this activity to last? ");
        _duration = int.Parse(Console.ReadLine());
        return _duration;
    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to the {_name}");
        Console.WriteLine(_description);

        // demander la durée
        GetDuration();

        Console.WriteLine("\nPrepare to begin...");
        Spinner(5);
        Console.Clear();
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done!!");
        Spinner(3);

        Console.WriteLine($"\nYou have completed {_duration} seconds of the {_name}.");
        Spinner(5);
    }

    public void Spinner(int seconds)
    {
        string[] animation = { "|", "/", "-", "\\" };
        int index = 0;

        DateTime endTime = DateTime.Now.AddSeconds(seconds);

        while (DateTime.Now < endTime)
        {
            Console.Write(animation[index]);
            Thread.Sleep(150);
            Console.Write("\b \b");
            index = (index + 1) % animation.Length;
        }
    }

    public void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }
}
