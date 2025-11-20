using System;

class Program
{
    static void Main(string[] args)
    {
        Reference x = new Reference("Nephi",2,25,26);
        string text = x.GetDisplayText();
        Console.WriteLine($"{text}");
        // Console.WriteLine("Hello World! This is the ScriptureMemorizer Project.");
    }
}