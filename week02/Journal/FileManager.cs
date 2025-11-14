using System;
using System.Collections.Generic;
using System.IO;

// Handles file saving and loading.

public class FileManager
{
    public void SaveJournalToFile(Journal journal, string filename)
    {
        try
        {
            List<string> lines = journal.ToFileLines();
            File.WriteAllLines(filename, lines);
            Console.WriteLine($"Journal saved to {filename}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving file: {ex.Message}");
        }
    }

    public Journal LoadJournalFromFile(string filename)
    {
        try
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("File does not exist.");
                return null;
            }

            List<string> lines = new List<string>(File.ReadAllLines(filename));
            return Journal.FromFileLines(lines);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading file: {ex.Message}");
            return null;
        }
    }
}
