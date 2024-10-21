namespace ProjectPartB_B1;

class HandOfCards : DeckOfCards, IHandOfCards
{
    /* A sorted-list of cards in our hand */
    public readonly SortedSet<PlayingCard> list = [];

    public void Add(PlayingCard card)
    {
        list.Add(card);
    }

    /* Use the SortedList's built-in min and max value property */
    public PlayingCard Highest => list.Max;
    public PlayingCard Lowest => list.Min;

    public override string ToString()
    {
        string ret = "";
        foreach (var card in list)
        {
            ret += card;
        }
        return ret += "\n";
    }
}