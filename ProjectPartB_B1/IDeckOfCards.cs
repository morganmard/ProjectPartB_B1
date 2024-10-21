﻿namespace ProjectPartB_B1;

interface IDeckOfCards
{
	public PlayingCard this[int idx] { get; }

	public int Count { get; }

	public abstract string ToString();

	public void Shuffle();

	public void Sort();

	public void Clear();

	public void CreateFreshDeck();

	public PlayingCard RemoveTopCard();
}