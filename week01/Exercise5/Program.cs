using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayResult();
    }
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program! ");
    }
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        string input = Console.ReadLine();
        int num = int.Parse(input);
        return num;
    }
    static int SquareNumber(int x)
    {
        int square = x*x;
        return square;
    }
    static void DisplayResult()
    {
        DisplayWelcome();
        string name = PromptUserName();
        int num = PromptUserNumber();
        int x = SquareNumber(num);
        Console.WriteLine($"{name}, the square of your number is {x}");
    }
}