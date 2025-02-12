using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    public class Deck
    {
        private Stack<Card> cards = new Stack<Card>();
        private static readonly string[] Suits = { "Cloves", "Diamond", "Heart", "Spade" };
        private static readonly string[] Ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Ace", "Jack", "Queen", "King" };

        public void Create()
        {
            cards.Clear();
            List<Card> deckList = new List<Card>();

            foreach (var suit in Suits)
            {
                foreach (var rank in Ranks)
                {
                    deckList.Add(new Card(suit, rank));
                }
            }

            // Push all cards into the stack in order
            deckList.Reverse();
            foreach (var card in deckList)
            {
                cards.Push(card);
            }

            Console.WriteLine("Deck created with 52 cards.");
        }

        public void Shuffle()
        {
            var deckArray = cards.ToArray();
            Random rng = new Random();
            int n = deckArray.Length;
            for (int i = n - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                (deckArray[i], deckArray[j]) = (deckArray[j], deckArray[i]);
            }

            cards.Clear();
            foreach (var card in deckArray)
            {
                cards.Push(card);
            }

            Console.WriteLine("Deck shuffled.");
        }

        public void Deal(int count)
        {
            if (count > cards.Count)
            {
                Console.WriteLine("Not enough cards in the deck.");
                return;
            }

            Console.WriteLine("Dealt Cards:");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(cards.Pop());
            }
        }

        public void Display()
        {
            Console.WriteLine($"Cards Remaining: {cards.Count}");
            foreach (var card in cards)
            {
                Console.WriteLine(card);
            }
        }
    }
}
