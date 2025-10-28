using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter your grade percentage: ");
        string input = Console.ReadLine();
        float grade = float.Parse(input);

        string letter = "";
        if (grade >= 90)
        {
            letter = "A";
            Console.WriteLine("Great job, you passed!");
        }
        else if (grade >= 80)
        {
            letter = "B";
            Console.WriteLine("Good work, you passed!");
        }
        else if (grade >= 70)
        {
            letter = "C";
            Console.WriteLine("You passed!");
        }
        else if (grade >= 60)
        {
            letter = "D";
            Console.WriteLine("Keep trying!");
        }
        else
        {
            letter = "F";
            Console.WriteLine("Better luck next time!");
        }
        Console.WriteLine($"Your letter grade is: {letter}");
    }
}
