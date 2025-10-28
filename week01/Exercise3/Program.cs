using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1,100);
        Console.WriteLine("READY!");
        // Console.WriteLine("What is the magic number? ");
        // string input1 = Console.ReadLine();
        // int magicNumber = int.Parse(input1);
        int i = 0;
        while (true)
        {
            i++;
            Console.Write("What is your guess? ");
            string input2 = Console.ReadLine();
            int guess = int.Parse(input2);

            if (guess > number)
            {
                Console.WriteLine("Lower");
            }
            else if (guess < number)
            {
                Console.WriteLine("Higher");
            }
            else
            {
                Console.WriteLine("Congratulations! You guessed it!");
                Console.WriteLine($"Number of guesses: {i}\n");
                Console.Write ("Want to continue? (yes/no): ");
                string input3 = Console.ReadLine();
                if (input3 == "yes")
                {
                    number = randomGenerator.Next(1,100);
                    i = 0;
                }
                else
                {
                    break;
                }
            }
        }
        
    }
}