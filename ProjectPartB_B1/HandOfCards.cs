namespace ProjectPartB_B1;

class HandOfCards : DeckOfCards, IHandOfCards
{
    /* A sorted-list of cards in our hand */
    private readonly SortedSet<PlayingCard> list = [];

    public void Add(PlayingCard card)
    {
        list.Add(card);
    }

    /* Use the SortedList's built-in min and max value property */
    public PlayingCard Highest => list.Max;
    public PlayingCard Lowest => list.Min;
}
