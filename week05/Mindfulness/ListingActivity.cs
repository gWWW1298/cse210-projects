public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
    {
        _count = 0;

        SetActivity(
            "Listing Activity",
            "This activity helps you reflect on the good things in your life.",
            0
        );
    }

    public void Run()
    {
        DisplayStartingMessage();
        int duration = GetDuration();

        Random rand = new Random();
        string selectedPrompt = _prompts[rand.Next(_prompts.Count)];

        Console.WriteLine("\nList as many responses as you can to the following prompt:");
        Console.WriteLine($"--- {selectedPrompt} ---");
        Console.WriteLine("\nYou may begin in:");
        ShowCountdown(5);

        _count = 0;
        DateTime endTime = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string response = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(response))
                _count++;
        }

        Console.WriteLine($"\nYou listed {_count} items!");

        DisplayEndingMessage();
    }
}
