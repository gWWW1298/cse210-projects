
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
    }
    public void Run()
    {
        DisplayStartingMessage();
        Random rand = new Random();
        int promptIndex = rand.Next(_prompts.Count);
        string selectedPrompt = _prompts[promptIndex];
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine($"--- {selectedPrompt} ---");
        Console.WriteLine("You may begin in:");
        ShowCountdown(5);

        DateTime endTime = DateTime.Now.AddSeconds(30); // Example duration of 30 seconds
        while (DateTime.Now < endTime)
        {
            string response = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(response))
            {
                _count++;
            }
        }

        Console.WriteLine($"You listed {_count} items!");
        DisplayEndingMessage();
    }
    public void GetRandomPrompt()
    {
        
    }
    public List<string> GetListFromUser()
    {
        return _prompts;
    }
}