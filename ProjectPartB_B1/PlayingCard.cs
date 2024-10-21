namespace ProjectPartB_B1;

public class PlayingCard : IComparable<PlayingCard>, IPlayingCard
{
	/* Internal array to translate PlayingCardColor from text-representation to a symbol */
	private static readonly string[] Color_Symbol = ["\u2663", "\u2666", "\u2665", "\u2660"];

	public PlayingCardColor Color { get; init; }
	public PlayingCardValue Value { get; init; }

	/* Implementing IComparable */
	public int CompareTo(PlayingCard? other) => Value.CompareTo(other?.Value);

	string ShortDescription
	{
		get
		{
			return $"{Color_Symbol[(int)Color]} {Value}, ";


			/* A version that doesn't need the Color_Symbol array

			string ret = "";

			switch (Color)
			{
				case PlayingCardColor.Clubs:
					ret = "\u2663";
					break;
				case PlayingCardColor.Diamonds:
					ret = "\u2666";
					break;
				case PlayingCardColor.Hearts:
					ret = "\u2665";
					break;
				case PlayingCardColor.Spades:
					ret = "\u2660";
					break;
			}
			return ret += $" {Value}, ";
			*/
		}
	}

	public override string ToString() => ShortDescription;

	public PlayingCard(PlayingCardColor _Color, PlayingCardValue _Value)
	{
		Color = _Color;
		Value = _Value;
	}
}
