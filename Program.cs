using System;

namespace DeckOfCards
{
    class Program
    {
        static void Main()
        {
            Deck deck = new Deck();
            while (true)
            {
                Console.WriteLine("\nDeck of Cards - Menu:");
                Console.WriteLine("1. Create Deck");
                Console.WriteLine("2. Shuffle Deck");
                Console.WriteLine("3. Deal Cards");
                Console.WriteLine("4. Display Deck");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine() ?? string.Empty; 
                switch (choice)
                {
                    case "1":
                        deck.Create();
                        break;
                    case "2":
                    
                        // refer to Deck.cs
                        // deck.Shuffle();
                        break;
                    case "3":
                        Console.Write("Enter number of cards to deal: ");
                        if (int.TryParse(Console.ReadLine(), out int count))
                        {
                            // refer to Deck.cs
                            //deck.Deal(count); 
                        }
                        else
                        {
                            Console.WriteLine("Invalid number.");
                        }
                        break;
                    case "4":
                        deck.Display();
                        break;
                    case "5":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}
