
using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;
    private const string SAVE_FILE = "goals.txt";

    public void Start()
    {
        LoadGoalsIfExists();
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine();
            DisplayPlayerInfo();
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Create goal");
            Console.WriteLine("2. List goals (names)");
            Console.WriteLine("3. List goals (details)");
            Console.WriteLine("4. Record event (complete goal)");
            Console.WriteLine("5. Save goals");
            Console.WriteLine("6. Load goals");
            Console.WriteLine("7. Display score");
            Console.WriteLine("0. Quit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoalNames(); break;
                case "3": ListGoalDetails(); break;
                case "4": RecordEvent(); break;
                case "5": SaveGoals(); break;
                case "6": LoadGoals(); break;
                case "7": Console.WriteLine($"Score: {_score} pts"); break;
                case "0": exit = true; SaveGoals(); break;
                default: Console.WriteLine("Invalid option."); break;
            }
        }

        Console.WriteLine("Goodbye!");
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Score: {_score} pts | Level: {GetLevel()}");
        Console.WriteLine($"Goals stored: {_goals.Count}");
    }

    private int GetLevel()
    {
        // Simple leveling: 1 level every 1000 points
        return (_score / 1000) + 1;
    }

    public void ListGoalNames()
    {
        if (_goals.Count == 0) { Console.WriteLine("No goals yet."); return; }
        int i = 1;
        foreach (var g in _goals)
        {
            Console.WriteLine($"{i}. {g.ShortName}");
            i++;
        }
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0) { Console.WriteLine("No goals yet."); return; }
        int i = 1;
        foreach (var g in _goals)
        {
            Console.WriteLine($"{i}. {g.GetDetailsString()}");
            i++;
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("Select goal type:");
        Console.WriteLine("1. SimpleGoal");
        Console.WriteLine("2. EternalGoal");
        Console.WriteLine("3. ChecklistGoal");
        Console.Write("Choice: ");
        string t = Console.ReadLine();

        Console.Write("Short name: ");
        string name = Console.ReadLine();
        Console.Write("Description: ");
        string desc = Console.ReadLine();

        if (t == "1")
        {
            Console.Write("Points awarded when complete (int): ");
            int pts = IntParseOrAsk();
            var g = new SimpleGoal(name, desc, pts);
            _goals.Add(g);
            Console.WriteLine("Simple goal created.");
        }
        else if (t == "2")
        {
            Console.Write("Points awarded each time (int): ");
            int pts = IntParseOrAsk();
            var g = new EternalGoal(name, desc, pts);
            _goals.Add(g);
            Console.WriteLine("Eternal goal created.");
        }
        else if (t == "3")
        {
            Console.Write("Points awarded each time (int): ");
            int pts = IntParseOrAsk();
            Console.Write("Target times to complete (int): ");
            int target = IntParseOrAsk();
            Console.Write("Bonus points when completed (int): ");
            int bonus = IntParseOrAsk();
            var g = new ChecklistGoal(name, desc, pts, target, bonus);
            _goals.Add(g);
            Console.WriteLine("Checklist goal created.");
        }
        else
        {
            Console.WriteLine("Unknown type.");
        }
    }

    private int IntParseOrAsk()
    {
        while (true)
        {
            string s = Console.ReadLine();
            if (int.TryParse(s, out int v)) return v;
            Console.Write("Invalid integer, try again: ");
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0) { Console.WriteLine("No goals to record."); return; }
        ListGoalNames();
        Console.Write("Choose goal number to record event for: ");
        if (!int.TryParse(Console.ReadLine(), out int idx) || idx < 1 || idx > _goals.Count)
        {
            Console.WriteLine("Invalid choice.");
            return;
        }

        Goal g = _goals[idx - 1];
        int awarded = g.RecordEvent();
        _score += awarded;
        Console.WriteLine($"Added {awarded} points. New score: {_score}");
    }

    public void SaveGoals()
    {
        try
        {
            using (StreamWriter sw = new StreamWriter(SAVE_FILE))
            {
                // first line score
                sw.WriteLine(_score);
                foreach (var g in _goals)
                {
                    sw.WriteLine(g.GetStringRepresentation());
                }
            }
            Console.WriteLine($"Saved {_goals.Count} goals to {SAVE_FILE} (score {_score}).");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving goals: {ex.Message}");
        }
    }

    public void LoadGoalsIfExists()
    {
        if (File.Exists(SAVE_FILE))
        {
            LoadGoals();
        }
    }

    public void LoadGoals()
    {
        try
        {
            if (!File.Exists(SAVE_FILE))
            {
                Console.WriteLine("Save file not found.");
                return;
            }

            string[] lines = File.ReadAllLines(SAVE_FILE);
            if (lines.Length == 0)
            {
                Console.WriteLine("Save file empty.");
                return;
            }

            int idxLine = 0;
            if (int.TryParse(lines[idxLine], out int sc))
            {
                _score = sc;
            }
            else
            {
                _score = 0;
            }
            idxLine++;

            _goals.Clear();
            for (; idxLine < lines.Length; idxLine++)
            {
                string line = lines[idxLine];
                if (string.IsNullOrWhiteSpace(line)) continue;
                string[] parts = SplitPreserveEscapes(line);
                string type = parts[0];
                if (type == "SimpleGoal")
                {
                    var g = SimpleGoal.Parse(parts);
                    _goals.Add(g);
                }
                else if (type == "EternalGoal")
                {
                    var g = EternalGoal.Parse(parts);
                    _goals.Add(g);
                }
                else if (type == "ChecklistGoal")
                {
                    var g = ChecklistGoal.Parse(parts);
                    _goals.Add(g);
                }
                else
                {
                    Console.WriteLine($"Unknown goal type in save: {type}");
                }
            }

            Console.WriteLine($"Loaded {_goals.Count} goals. Score: {_score}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading goals: {ex.Message}");
        }
    }

    // helper to split a saved line with escaped '|' tokens (escape uses "/|")
    private static string[] SplitPreserveEscapes(string line)
    {
        List<string> parts = new List<string>();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        bool escaping = false;
        for (int i = 0; i < line.Length; i++)
        {
            if (line[i] == '/' && i + 1 < line.Length && line[i + 1] == '|')
            {
                // escaped pipe -> append '|' and skip the '/'
                sb.Append('|');
                i++; // skip '|'
            }
            else if (line[i] == '|')
            {
                parts.Add(sb.ToString());
                sb.Clear();
            }
            else
            {
                sb.Append(line[i]);
            }
        }
        parts.Add(sb.ToString());
        return parts.ToArray();
    }
}
