using System;

class Program
{
    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("--------------------");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Listing Activity");
            Console.WriteLine("3. Reflecting Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.StartBreathingExercise(); // ✔ SANS ARGUMENT

                    Console.WriteLine("\nPress Enter to return to menu...");
                    Console.ReadLine();
                    break;

                case "2":
                    Console.Clear();
                    ListingActivity listing = new ListingActivity();
                    listing.Run(); // ✔ SANS ARGUMENT

                    Console.WriteLine("\nPress Enter to return to menu...");
                    Console.ReadLine();
                    break;

                case "3":
                    Console.Clear();
                    ReflectingActivity reflecting = new ReflectingActivity();
                    reflecting.Run(); // ✔ SANS ARGUMENT

                    Console.WriteLine("\nPress Enter to return to menu...");
                    Console.ReadLine();
                    break;

                case "4":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Press Enter to continue.");
                    Console.ReadLine();
                    break;
            }
        }
    }
}
