using System;

// *** EXCEED REQUIREMENTS ***
// I added a "Mood" field to each journal entry.
// This helps users track their emotional patterns over time
// and adds more value than the basic journaling application.

class Program
{
    static void Main(string[] args)
    {
        var promptGenerator = new PromptGenerator();
        var journal = new Journal();
        var fileManager = new FileManager();

        bool running = true;

        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("Journal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Clear current journal entries");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": // Write entry
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine();
                    Console.WriteLine($"Prompt: {prompt}");

                    Console.Write("Your response: ");
                    string response = Console.ReadLine();

                    Console.Write("How are you feeling today? (e.g., Happy, Sad, Tired): ");
                    string mood = Console.ReadLine();

                    journal.AddEntry(prompt, response, mood);
                    Console.WriteLine("Entry added successfully!");
                    break;

                case "2": // Display entries
                    journal.DisplayEntries();
                    break;

                case "3": // Save
                    Console.Write("Enter filename to save (e.g. journal.txt): ");
                    string saveFile = Console.ReadLine();
                    fileManager.SaveJournalToFile(journal, saveFile);
                    break;

                case "4": // Load
                    Console.Write("Enter filename to load (e.g. journal.txt): ");
                    string loadFile = Console.ReadLine();
                    Journal loadedJournal = fileManager.LoadJournalFromFile(loadFile);
                    if (loadedJournal != null)
                    {
                        journal = loadedJournal;
                        Console.WriteLine("Journal loaded successfully!");
                    }
                    break;

                case "5":
                    journal.ClearEntries();
                    Console.WriteLine("Journal entries cleared.");
                    break;

                case "6":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }

        Console.WriteLine("Goodbye!");
    }
}
