using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        List<int> nbr = new List<int>();
        int max = 0;
        int i = 0;
        // int x = 0;
        while (true)
        {
            // x++;
            Console.Write("Enter number: ");
            string input = Console.ReadLine();
            int num = int.Parse(input);
            nbr.Add(num);
            if (num == 0)
            {
                break;
            }
        }
        foreach (int x in nbr)
        {
            i = i+x;
            if (x > max)
            {
                max = x;
            }
        }
        int a = (nbr.Count)-1;
        float average = (float)i / a;
        Console.WriteLine($"The sum is: {i}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");

    }
}