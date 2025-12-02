
using System;
using System.Collections.Generic;

public class AffirmationActivity : Activity
{
    private List<string> _affirmations = new List<string>()
    {
        "You are capable of amazing things.",
        "Every day is a new opportunity.",
        "Believe in yourself and all that you are.",
        "Your effort makes a difference.",
        "Stay positive, work hard, make it happen."
    };

    public AffirmationActivity()
    {
        SetActivity(
            "Affirmation Activity",
            "This activity will display positive affirmations to boost your mood and confidence.",
            0
        );
    }

    public void Run()
    {
        DisplayStartingMessage();

        int duration = GetDuration();
        DateTime endTime = DateTime.Now.AddSeconds(duration);
        Random rand = new Random();

        Console.WriteLine("\nRead each affirmation and take a deep breath...");

        while (DateTime.Now < endTime)
        {
            string affirmation = _affirmations[rand.Next(_affirmations.Count)];
            Console.WriteLine($"> {affirmation}");
            Spinner(3); // pause pour lire l'affirmation
        }

        DisplayEndingMessage();
    }
}
