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
					case "J":
						return 11;
					case "Q":
						return 12;
					case "K":
						return 13;
					case "A":
						return 14;
					default:
						return 0;
				}
			}
		});
		
		return cards.ToList();
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
			var handType = winningsCalculator.GetHandType(cards);
			var bid = int.Parse(parts[1]);
			
			var hand = new Hand
			{
				Cards = cards,
				HandType = handType,
				Bid = bid
			};
			hands.Add(hand);
		}
		
		var overallWinnings = winningsCalculator.GetOverallWinnings(hands);
		Console.WriteLine(overallWinnings);
	}
}