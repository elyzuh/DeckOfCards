using System;

namespace DeckOfCards
{
    public class Card
    {
        public string Suit { get; }
        public string Rank { get; }

        public Card(string suit, string rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public override string ToString()
        {
            return $"Suit: {Suit}; Rank: {Rank}";
        }
    }
}
