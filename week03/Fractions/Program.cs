using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction x1 = new Fraction();
        Fraction x2 = new Fraction(5);
        Fraction x3 = new Fraction(3,4);

        // Console.WriteLine($"top x1={x1.GetTop()}");
        // Console.WriteLine($"bottom x1={x1.GetBottom()}");
        
        // x1.SetTop(2);
        // x1.SetBottom(3);
        // Console.WriteLine($"top x1={x1.GetTop()}");
        // Console.WriteLine($"bottom x1={x1.GetBottom()}");

        Console.WriteLine($"{x1.GetFractionString()}");
        Console.WriteLine($"{x1.GetDecimalValue()}");

        Console.WriteLine($"{x2.GetFractionString()}");
        Console.WriteLine($"{x2.GetDecimalValue()}");

        Console.WriteLine($"{x3.GetFractionString()}");
        Console.WriteLine($"{x3.GetDecimalValue()}");

    }
}