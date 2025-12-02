
public class BreathingActivity : Activity
{
    private int _breathInDuration;
    private int _breathOutDuration;

    public BreathingActivity()
    {
        _breathInDuration = 4;
        _breathOutDuration = 6;
    }

    public void StartBreathingExercise(int durationInSeconds)
    {
        DisplayStartingMessage();
        int elapsed = 0;
        while (elapsed < durationInSeconds)
        {
            Console.WriteLine("Breathe in...");
            ShowCountdown(_breathInDuration);
            Console.WriteLine("Breathe out...");
            ShowCountdown(_breathOutDuration);
            elapsed += _breathInDuration + _breathOutDuration;
        }
        DisplayEndingMessage();
    }
}