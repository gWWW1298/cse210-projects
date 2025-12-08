using System;
using System.Collections.Generic;

public class GoalManager
{
    private int _totalPoints = 0;
    private int _level = 1;
    private int _nextLevelThreshold = 1000;

    private List<Goal> _goals = new List<Goal>();

    // Getters
    public int GetTotalPoints() { return _totalPoints; }
    public int GetLevel() { return _level; }

    // Add points + Level-Up system
    public void AddPoints(int pts)
    {
        _totalPoints += pts;

        if (_totalPoints >= _nextLevelThreshold)
        {
            _level++;
            _nextLevelThreshold += 1000;

            Console.WriteLine($"\n*** Congratulations! You reached Level {_level}! ***\n");
        }
    }

    public void AddGoal(Goal g)
    {
        _goals.Add(g);
    }

    public void ListGoals()
    {
        Console.WriteLine("\nYour Goals:\n");

        int i = 1;
        foreach (Goal g in _goals)
        {
            Console.WriteLine($"{i}. {g.GetStatus()} {g.GetName()} ({g.GetDescription()})");
            i++;
        }
    }

    public void RecordEvent()
    {
        ListGoals();

        Console.Write("\nWhich goal did you accomplish? ");
        int index = int.Parse(Console.ReadLine()) - 1;

        int earned = _goals[index].RecordEvent();
        AddPoints(earned);

        Console.WriteLine($"\nYou earned {earned} points!");
        Console.WriteLine($"Total points: {GetTotalPoints()}");
        Console.WriteLine($"Current level: {GetLevel()}\n");
    }
}