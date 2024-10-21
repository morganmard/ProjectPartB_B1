namespace ProjectPartB_B1;

class Program
{
	static void Main()
	{
		DeckOfCards myDeck = new();
		myDeck.CreateFreshDeck();
		Console.WriteLine($"\nA freshly created deck with {myDeck.Count} cards:");
		Console.WriteLine(myDeck);

		Console.WriteLine($"\nA sorted deck with {myDeck.Count} cards:");
		myDeck.Sort();
		Console.WriteLine(myDeck);

		Console.WriteLine($"\nA shuffled deck with {myDeck.Count} cards:");
		myDeck.Shuffle();
		Console.WriteLine(myDeck);


		HandOfCards player1 = new();
		HandOfCards player2 = new();

		/* We use the readNum function to read a number with a custom message */
		int NrOfCards = readNum("Enter number of cards to draw (1 - 5)");
		int NrOfRounds = readNum("Enter number of rounds to play (1 - 5)");

		/* Run the game 'NrOfRounds' times */
		while (NrOfRounds-- > 0)
		{
			Console.WriteLine($"Round {NrOfRounds + 1}:");

			/* Make sure we clear the deck before making a fresh one */
			myDeck.Clear();
			myDeck.CreateFreshDeck();
			myDeck.Shuffle();
			Deal(myDeck, NrOfCards, player1, player2);
			DetermineWinner(player1, player2);
		}
	}

	private static int readNum(string s)
	{
		/* 5 is the highest number of cards AND rounds allowed so we make it a constant */
		const int MAX_VAL = 5;

		/* Here we will save our read-number */
		int ret;

		/* Keep printing our message each time we don't give a number between 0 and MAX_VAL (and print it once before reading */
		do
		{
			Console.WriteLine(s);
		} while (tryRead(MAX_VAL, out ret) == false);

		return ret;
	}

	private static bool tryRead(int max, out int val)
	{
		/* Try reading a number and then checking if it's between 1 and max(inclusive) */
		if (int.TryParse(Console.ReadLine(), out val))
		{
			return val > 0 && val <= max;
		}
		return false;
	}

	private static void Deal(DeckOfCards myDeck, int nrCardsToPlayer, HandOfCards player1, HandOfCards player2)
	{
		Console.WriteLine();
		for (int i = 0; i < nrCardsToPlayer; ++i)
		{
			var card = myDeck.RemoveTopCard();
			Console.WriteLine($"Player one got dealt: {card}");
			player1.Add(card);

			card = myDeck.RemoveTopCard();
			Console.WriteLine($"Player Two got dealt: {card}");
			player2.Add(card);

			Console.WriteLine();
		}
		Console.WriteLine();
	}

	private static void DetermineWinner(HandOfCards player1, HandOfCards player2)
	{
		Console.WriteLine($"Player one has the following {player1.list.Count} cards: {player1}");
		Console.WriteLine($"Player one has the following {player2.list.Count} cards: {player2}");

		/* Check the highest card of both players and compare them */
		int winner = player1.Highest.Value - player2.Highest.Value;

		/* Print the winner based on the compare above */
		Console.WriteLine(winner switch
		{
			< 0 => "Player 2 won\n",
			0 => "It's a draw\n",
			> 0 => "Player 1 won\n",
		});


		/* This is an easier version using direct comparison and if/else instead of switch 

				if (player1.Highest.Value > player2.Highest.Value)
				{
					Console.WriteLine("Player 1 won");
				}
				else if (player2.Highest.Value > player1.Highest.Value)
				{
					Console.WriteLine("Player 2 won");
				}
				else
				{
					Console.WriteLine("It's a draw");
				}
		*/
	}
}
