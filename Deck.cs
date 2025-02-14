using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace DeckOfCards
{
    public class Deck
    {
        private Stack<Card> cards = new Stack<Card>();
        private static readonly string[] Suits = { "Cloves", "Diamond", "Heart", "Spade" };
        private static readonly string[] Ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

        public void Create()
        {
            if (cards.Count > 0)
            {
                Console.WriteLine("A deck already exists! Creating a new one will replace the current deck.");
                Console.Write("Do you want to proceed? (yes/no): ");
                string response = (Console.ReadLine()?.Trim().ToLower()) ?? string.Empty; // Use a fallback empty string if null

                if (response != "yes")
                {
                    Console.WriteLine("Deck creation canceled.");
                    return;
                }
            }

            cards.Clear();
            List<Card> deckList = new List<Card>();

            foreach (var suit in Suits)
            {
                foreach (var rank in Ranks)
                {
                    deckList.Add(new Card(suit, rank));
                }
            }

            deckList.Reverse();
            foreach (var card in deckList)
            {
                cards.Push(card);
            }

            Console.WriteLine("Deck created with 52 cards.");
        }




        public void Shuffle(int count)
        {
            if (cards.Count == 0)
            {
                Console.WriteLine("Deck is empty! Create a deck first before shuffling.");
                return;
            }

            if (count <= 0)
            {
                Console.WriteLine("Shuffle count must be at least 1.");
                return;
            }

            List<Card> deckList = new List<Card>(cards);
            Random rng = new Random();

            for (int i = 0; i < count; i++)
            {
                for (int j = deckList.Count - 1; j > 0; j--)
                {
                    int k = rng.Next(j + 1);
                    (deckList[j], deckList[k]) = (deckList[k], deckList[j]); // Swap cards
                }
            }

            // Clear the stack and push shuffled cards back
            cards.Clear();
            foreach (var card in deckList)
            {
                cards.Push(card);
            }

            Console.WriteLine($"Deck shuffled {count} time(s).");
        }


        public void Deal(int count)
        {
            if (cards.Count == 0)
            {
                Console.WriteLine("Deck is empty! No cards to deal.");
                return;
            }

            if (count <= 0)
            {
                Console.WriteLine("Please enter a valid number of cards to deal (at least 1).");
                return;
            }

            if (count > cards.Count)
            {
                Console.WriteLine($"Not enough cards left! Only {cards.Count} card(s) available.");
                count = cards.Count; // Adjust to remaining cards
            }

            Console.WriteLine($"Dealing {count} card(s):");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(cards.Pop()); // Remove and show each dealt card
            }

            Console.WriteLine($"Cards Remaining: {cards.Count}");
        }


        public void Display()
        {
            if (cards.Count == 0)
            {
                Console.WriteLine("Deck is empty!");
                return;
            }

            foreach (var card in cards)
            {
                Console.WriteLine(card);
            }
            Console.WriteLine($"Cards Remaining: {cards.Count}");
        }
    }
}
