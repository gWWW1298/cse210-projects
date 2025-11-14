using System;
using System.Collections.Generic;

// Generates random prompts.

public class PromptGenerator
{
    private List<string> _prompts = new List<string>();
    private Random _random = new Random();

    public PromptGenerator()
    {
        _prompts.Add("Who was the most interesting person I interacted with today?");
        _prompts.Add("What was the best part of my day?");
        _prompts.Add("What challenged me today?");
        _prompts.Add("What am I grateful for today?");
        _prompts.Add("If I could relive one moment from today, what would it be?");
        _prompts.Add("What made me smile today?");
    }

    public string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }
}
