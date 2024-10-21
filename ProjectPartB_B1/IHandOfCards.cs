namespace ProjectPartB_B1;

interface IHandOfCards : IDeckOfCards
{
    public void Add(PlayingCard card);

    public PlayingCard Highest { get; }

    public PlayingCard Lowest { get; }

}
