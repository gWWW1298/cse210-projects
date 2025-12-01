using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Homework Project.\n");
        
        Assignment zah = new Assignment("anthony", "addition");
        string summary = zah.GetSummary();
        Console.WriteLine(summary+"\n");

        MathAssignment test1 = new MathAssignment("Yves", "Fraction", "Section 7.3", "Problems 8-19");
        string test2 = test1.GetHomeworkList();
        Console.WriteLine(test2+"\n");

        WritingAssignment essay = new WritingAssignment("Marco", "European History", "The Causes of World War II");
        string test3 = essay.GetWritingInfo();
        Console.WriteLine(test3+"\n");
    }
}