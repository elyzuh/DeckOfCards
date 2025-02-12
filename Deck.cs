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

        }

        public void Deal(int count)
        {

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
