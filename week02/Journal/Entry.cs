using System;

// Models a single journal entry. Only contains entry data and formatting.

public class Entry
{
    private string _date;
    private string _prompt;
    private string _response;
    private string _mood;

    public string Date { get { return _date; } }
    public string Prompt { get { return _prompt; } }
    public string Response { get { return _response; } }
    public string Mood { get { return _mood; } }

    public Entry(string date, string prompt, string response, string mood)
    {
        _date = date;
        _prompt = prompt;
        _response = response;
        _mood = mood;
    }

    public override string ToString()
    {
        return $"Date: {_date}\nMood: {_mood}\nPrompt: {_prompt}\nResponse: {_response}\n";
    }

    public string ToFileString()
    {
        return $"{_date}|{_mood}|{_prompt}|{_response}";
    }

    public static Entry FromFileString(string line)
    {
        string[] parts = line.Split('|');
        if (parts.Length < 4)
            return null;

        string date = parts[0];
        string mood = parts[1];
        string prompt = parts[2];
        string response = parts[3];

        return new Entry(date, prompt, response, mood);
    }
}
