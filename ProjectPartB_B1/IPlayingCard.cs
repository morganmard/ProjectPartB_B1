namespace ProjectPartB_B1;

public enum PlayingCardColor
{
	Clubs = 0, Diamonds, Hearts, Spades
}

public enum PlayingCardValue
{
	Two = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten,
	Knight, Queen, King, Ace
}

interface IPlayingCard
{
	public PlayingCardColor Color { get; init; }

	public PlayingCardValue Value { get; init; }

	public abstract string ToString();
}
