using System;
using System.Collections.Generic;

// Models a full journal. Responsible only for storing and displaying entries.
public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(string prompt, string response, string mood)
    {
        string date = DateTime.Now.ToString("yyyy-MM-dd");
        Entry entry = new Entry(date, prompt, response, mood);
        _entries.Add(entry);
    }

    public void DisplayEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries to display.");
            return;
        }

        Console.WriteLine("\n--- Journal Entries ---");
        foreach (Entry entry in _entries)
        {
            Console.WriteLine(entry.ToString());
        }
    }

    public void ClearEntries()
    {
        _entries.Clear();
    }

    public List<string> ToFileLines()
    {
        List<string> lines = new List<string>();
        foreach (Entry e in _entries)
        {
            lines.Add(e.ToFileString());
        }
        return lines;
    }

    public static Journal FromFileLines(List<string> lines)
    {
        Journal journal = new Journal();
        foreach (string line in lines)
        {
            Entry entry = Entry.FromFileString(line);
            if (entry != null)
            {
                journal._entries.Add(entry);
            }
        }
        return journal;
    }
}
