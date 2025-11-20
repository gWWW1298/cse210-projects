// As an exceed requirement, i add code (to the Scripture class and Program class) to let the user know about the number of hidden, remaining, total words at the bottom.
using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello World! This is the ScriptureMemorizer Project.");

        // Reference x = new Reference("Nephi",2,25,26);
        // string text = x.GetDisplayText();
        // Console.WriteLine($"{text}");

        string dac = " There is a law, irrevocably decreed in heaven before the foundations of this world, upon which all blessings are predicated-"+
        "And when we obtain any blessing from God, it is by obedience to that law upon which it is predicated.";
        
        //Reference: Doctrine and Covenants 130: 20-21 
        Reference x = new Reference("Doctrine and Covenants",130,20,21);

        Scripture scripture = new Scripture(x, dac); 

        while (true)
        {
            Console.Clear();
            Console.Write(x.GetDisplayText());
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            // Exceed requirement
            int hidden = scripture.GetHiddenWordCount();
            int total = scripture.GetTotalWordCount();
            Console.WriteLine($"Words hidden: {hidden}/{total}");
            Console.WriteLine($"Words remaining: {total - hidden}");
            Console.WriteLine();
            
            // verify if all words are hidden
            if (scripture.IsCompletelyHidden())
            {
                
                Console.WriteLine("All words are hidden. Press Enter to exit.");
                Console.ReadLine();
                break;
            }

            Console.WriteLine("Press Enter to hide more words or type 'quit' to exit:");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            // hide 2 to 4 random words
            scripture.HideRandomWords(3);
        } 
        
    }
}