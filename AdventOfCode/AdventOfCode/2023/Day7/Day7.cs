namespace AdventOfCode._2023.Day7
{
    public class Day7
    {
        public int Run(string input, bool replaceJokers = false)
        {
            var lines = input.Split("\n");
            var hands = new List<Hand>();
            foreach (var line in lines)
            {
                var parts = line.Split(" ");
                var handPart = parts[0];
                var cardChars = handPart.ToCharArray();
                var cards = GetCards(cardChars, replaceJokers);

                HandType handType;
                if (replaceJokers)
                {
                    var jokersReplacedCards = GetCardsWithJokersReplaced(cards);
                    handType = GetHandType(jokersReplacedCards);
                }
                else
                {
                    handType = GetHandType(cards);
                }

                var bid = int.Parse(parts[1]);

                var hand = new Hand
                {
                    Cards = cards,
                    HandType = handType,
                    Bid = bid
                };
                hands.Add(hand);
            }

            return GetOverallWinnings(hands);
        }

        private static List<int> GetCards(char[] cardChars, bool replaceJokers = false)
        {
            var cards = cardChars.Select(x =>
            {
                var fromAscii = $"{x}";
                if (Char.IsNumber(x))
                {
                    return int.Parse(fromAscii);
                }
                else
                {
                    return fromAscii switch
                    {
                        "T" => 10,
                        "Q" => 12,
                        "K" => 13,
                        "A" => 14,
                        "J" => replaceJokers ? 1 : 11,
                        _ => 0,
                    };
                }
            });

            return cards.ToList();
        }

        private static List<int> GetCardsWithJokersReplaced(List<int> cards)
        {
            var jokerCount = cards.Count(x => x == 1);
            if (jokerCount == 0 || jokerCount == 5)
            {
                return cards;
            }

            var nonJokers = cards.Where(x => x != 1);
            var groups = nonJokers.GroupBy(x => x);
            var replacementCard = 0;
            var largestGroup = groups.OrderByDescending(x => x.Count()).First();
            replacementCard = largestGroup.Key;

            return cards.Select(x => x == 1 ? replacementCard : x).ToList();
        }

        private static HandType GetHandType(List<int> cards)
        {
            var groups = cards.GroupBy(x => x);
            var groupCount = groups.Count();
            var handType = HandType.None;
            if (groupCount == 1)
            {
                handType = HandType.FiveOfAKind;
            }
            else if (groupCount == 2)
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
            else if (groupCount == 3)
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
            else if (groupCount == 4)
            {
                handType = HandType.OnePair;
            }
            else // 5 groups
            {
                handType = HandType.HighCard;
            }

            return handType;
        }

        private static int GetOverallWinnings(List<Hand> hands)
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

    public class Hand
    {
        public List<int> Cards = [];
        public HandType HandType;
        public int Bid;
    }
}
