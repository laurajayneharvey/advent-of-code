using System;
using System.Collections.Generic;
using System.Linq;

public enum HandType
{
	None = 0,
	HighCard = 1,
	OnePair = 2,
	TwoPair = 3,
	ThreeOfAKind = 4,
	FullHouse = 5,
	FourOfAKind = 6,
	FiveOfAKind = 7
}

public class Hand {
	public List<int> Cards;
	public HandType HandType;
	public int Bid;
}

public class WinningsCalculator
{
	public List<int> GetCards(char[] cardChars)
	{
		var cards = cardChars.Select(x => {
			var fromAscii = $"{x}";
			if (Char.IsNumber(x))
			{
				return int.Parse(fromAscii);
			} else {
				switch(fromAscii)
				{
					case "T":
						return 10;
					case "Q":
						return 12;
					case "K":
						return 13;
					case "A":
						return 14;
					case "J":
						return 1;
					default:
						return 0;
				}
			}
		});
		
		return cards.ToList();
	}
	
	public List<int> GetCardsWithJokersReplaced(List<int> cards)
	{
		var jokerCount = cards.Count(x => x == 1);
		if (jokerCount == 0 || jokerCount == 5)
		{
			// ????? -> nothing to do
			// JJJJJ -> already 5 of a kind
			return cards;
		}
		
		// JJJJX -> make it 5 of a kind
		// JJJXX JJJXY
		// JJXXX JJXXY JJXYZ ||
		// JXXXX JXXXY JXXYY JXXYZ JXYZA
		var nonJokers = cards.Where(x => x != 1);
		var groups = nonJokers.GroupBy(x => x);
		var replacementCard = 0;
		var largestGroup = groups.OrderByDescending(x => x.Count()).First();
		replacementCard = largestGroup.Key;
		return cards.Select(x => x == 1 ? replacementCard : x).ToList();
	}
	
	public HandType GetHandType(List<int> cards)
	{
		var groups = cards.GroupBy(x => x);
		var handType = HandType.None;
		if (groups.Count() == 1)
		{
			handType = HandType.FiveOfAKind;
		}
		else if (groups.Count() == 2)
		{
			if (groups.Any(group => group.Count() == 4))
			{
				handType = HandType.FourOfAKind;
			}
			else
			{
				handType = HandType.FullHouse;
			}
		}
		else if (groups.Count() == 3)
		{
			if (groups.Any(group => group.Count() == 3))
			{
				handType = HandType.ThreeOfAKind;
			}
			else
			{
				handType = HandType.TwoPair;
			}		
		}
		else if (groups.Count() == 4)
		{
			handType = HandType.OnePair;	
		}
		else // 5 groups
		{
			handType = HandType.HighCard;
		}
		
		return handType;
	}
	
	public int GetOverallWinnings(List<Hand> hands)
	{
		var orderedHands = hands
			.OrderByDescending(hand => hand.Cards[4])
			.OrderByDescending(hand => hand.Cards[3])
			.OrderByDescending(hand => hand.Cards[2])
			.OrderByDescending(hand => hand.Cards[1])
			.OrderByDescending(hand => hand.Cards[0])
			.OrderByDescending(hand => (int)hand.HandType).ToList();
		
		var overallWinnings = 0;
		for (var i = 0; i < orderedHands.Count; i++)
		{
			var ranking = orderedHands.Count - i;
			var winnings = orderedHands[i].Bid * ranking;
			overallWinnings += winnings;
		}
		
		return overallWinnings;
	}
}
			
public class Program
{
	public static void Main()
	{
		var winningsCalculator = new WinningsCalculator();
		var input = @"32T3K 765
T55J5 684
KK677 28
KTJJT 220
QQQJA 483";
		var lines = input.Split("\n");
		var hands = new List<Hand>();
		foreach (var line in lines)
		{
			var parts = line.Split(" ");
			var handPart = parts[0];
			var cardChars = handPart.ToCharArray();
			var cards = winningsCalculator.GetCards(cardChars);
			var jokersReplacedCards = winningsCalculator.GetCardsWithJokersReplaced(cards);
			var handType = winningsCalculator.GetHandType(jokersReplacedCards); // based on jokers replaced hand
			var bid = int.Parse(parts[1]);
			
			var hand = new Hand
			{
				Cards = cards, // jokers not replaced
				HandType = handType,
				Bid = bid
			};
			hands.Add(hand);
		}
		
		var overallWinnings = winningsCalculator.GetOverallWinnings(hands);
		Console.WriteLine(overallWinnings);
	}
}