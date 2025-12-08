// EXCEED REQUIREMENT:
// I added a simple gamification feature: a Level-Up system.
// Every time the user reaches a new 1000-point threshold,
// they advance to the next level and receive a celebration message.
// This adds motivation and enhances the gameplay experience.

using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        int choice = 0;

        while (choice != 5)
        {
            Console.WriteLine("\n===== Eternal Quest =====");
            Console.WriteLine($"Total Points: {manager.GetTotalPoints()}");
            Console.WriteLine($"Level: {manager.GetLevel()}\n");

            Console.WriteLine("1. Create a new goal");
            Console.WriteLine("2. List goals");
            Console.WriteLine("3. Record an event");
            Console.WriteLine("5. Quit");

            Console.Write("\nYour choice: ");
            choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                Console.WriteLine("\nWhich type of goal?");
                Console.WriteLine("1. Simple Goal");
                Console.WriteLine("2. Eternal Goal");
                Console.WriteLine("3. Checklist Goal");

                int type = int.Parse(Console.ReadLine());

                Console.Write("\nName: ");
                string name = Console.ReadLine();

                Console.Write("Description: ");
                string desc = Console.ReadLine();

                Console.Write("Points: ");
                int points = int.Parse(Console.ReadLine());

                if (type == 1)
                {
                    manager.AddGoal(new SimpleGoal(name, desc, points));
                }
                else if (type == 2)
                {
                    manager.AddGoal(new EternalGoal(name, desc, points));
                }
                else if (type == 3)
                {
                    Console.Write("Target (how many times needed): ");
                    int target = int.Parse(Console.ReadLine());

                    Console.Write("Bonus when completed: ");
                    int bonus = int.Parse(Console.ReadLine());

                    manager.AddGoal(new ChecklistGoal(name, desc, points, target, bonus));
                }
            }
            else if (choice == 2)
            {
                manager.ListGoals();
            }
            else if (choice == 3)
            {
                manager.RecordEvent();
            }
        }

        Console.WriteLine("\nGoodbye!");
    }
}
