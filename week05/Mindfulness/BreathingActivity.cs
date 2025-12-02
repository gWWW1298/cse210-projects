public class BreathingActivity : Activity
{
    private int _breathInDuration;
    private int _breathOutDuration;

    public BreathingActivity()
    {
        _breathInDuration = 4;
        _breathOutDuration = 6;

        SetActivity(
            "Breathing Activity",
            "This activity will help you relax by guiding you through slow breathing.\nClear your mind and focus on your breathing.",
            0
        );
    }

    public void StartBreathingExercise()
    {
        // Demande la durée + message de départ + spinner
        DisplayStartingMessage();

        // Utilise la durée qui vient d’être récupérée par DisplayStartingMessage()
        int duration = GetDuration();
        int elapsed = 0;

        Console.WriteLine();

        while (elapsed < duration)
        {
            Console.Write("Breathe in... ");
            ShowCountdown(_breathInDuration);

            Console.Write("Now breathe out... ");
            ShowCountdown(_breathOutDuration);

            Console.WriteLine();

            elapsed += _breathInDuration + _breathOutDuration;
        }

        DisplayEndingMessage();
    }
}
