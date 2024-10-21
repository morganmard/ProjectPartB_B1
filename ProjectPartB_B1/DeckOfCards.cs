/* Import to use a secure random function */
using System.Security.Cryptography;

namespace ProjectPartB_B1;

class DeckOfCards() : IDeckOfCards
{
	/* A deck of cards is always 52, so we use a constant for it */
	private const int MAX_NR_CARDS = 52;

	/* Our internal list of 52 PlayingCards */
	private readonly List<PlayingCard> Deck = new(MAX_NR_CARDS);

	/* Indexer to be able to acess the list from our deck-varible directly */
	public PlayingCard this[int idx] => Deck[idx];

	/* Getter for the amount of cards (left) in the deck */
	public int Count { get => Deck.Count; }

	public void Shuffle()
	{
		/*  
			Knuth's variation of Fisher-Yates algorithm to shuffle an array.
			Implementation cross-referenced with a implementation by Robert Sedgewick.

			For more information about the algorithm see:
			https://en.wikipedia.org/wiki/Fisher-Yates_shuffle

			Implementation can be found here:
			https://algs4.cs.princeton.edu/11model/Knuth.java
		*/

		/* We create a static instance of a cryptographic-secure rng inside the class RandomNumberGenerator */
		RandomNumberGenerator.Create();
		for (int i = 0; i < Count; ++i)
		{
			/* Here we use the RandomNumberGenerator's internal rng to get a integer between 0 and i */
			int j = RandomNumberGenerator.GetInt32(i + 1);

			/* Tuple swap */
			(Deck[i], Deck[j]) = (Deck[j], Deck[i]);
		}


		/* A simpler shuffle that doesn't need the secure random

		var rnd = new Random();
		for (int i = 0; i < 10000; ++i)
		{
			int p = rnd.Next(Count);
			int q = rnd.Next(Count);

			var temp = Deck[p];
			Deck[p] = Deck[q];
			Deck[q] = temp;
		}
		*/
	}

	public void Sort()
	{
		Deck.Sort();
	}

	public void Clear()
	{
		Deck.Clear();
	}

	public void CreateFreshDeck()
	{
		/* Loop through the both-enums to create a whole deck of colours */
		foreach (var Color in Enum.GetValues<PlayingCardColor>())
		{
			foreach (var Value in Enum.GetValues<PlayingCardValue>())
			{
				Deck.Add(new PlayingCard(Color, Value));
			}
		}
	}

	public PlayingCard RemoveTopCard()
	{
		/* Create a copy of the top-most card */
		var card = Deck[0];
		/* Remove the top-most card of the deck */
		Deck.RemoveAt(0);
		return card;
	}

	public override string ToString()
	{
		string ret = "";
		Deck.ForEach(card => ret += card);
		return ret + "\n";
	}
}
