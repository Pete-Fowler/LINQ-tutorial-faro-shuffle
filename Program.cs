using LinqFaroShuffle;
using System;
using System.Collections.Generic;
using System.Linq;

// Program.cs
// The Main() method

IEnumerable<string> Suits()
{
    yield return "clubs";
    yield return "diamonds";
    yield return "hearts";
    yield return "spades";
}

IEnumerable<string> Ranks()
{
    yield return "two";
    yield return "three";
    yield return "four";
    yield return "five";
    yield return "six";
    yield return "seven";
    yield return "eight";
    yield return "nine";
    yield return "ten";
    yield return "jack";
    yield return "queen";
    yield return "king";
    yield return "ace";
}

var startingDeck = from s in Suits()
                   from r in Ranks()
                   select new { Suit = s, Rank = r };

//foreach (var card in startingDeck)
//{
//    Console.WriteLine(card);
//}

var top = startingDeck.Take(26);
var bottom = startingDeck.Skip(26);
var deck = Extensions.InterleaveSequenceWith(top, bottom);

deck = startingDeck;

var i = 0;
do
{
    deck = deck.Take(26).InterleaveSequenceWith(deck.Skip(26));
    i++;
} while (!Extensions.IsDeckEqual(startingDeck, deck));

Console.WriteLine(i);

