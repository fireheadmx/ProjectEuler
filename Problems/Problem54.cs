using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ProjectEuler.Problems
{
    class Problem54
    {
        private Dictionary<char, int> card;
        private Dictionary<string, int> hand;

        public Problem54()
        {
            card = new Dictionary<char, int>();
            card.Add('2', 2);
            card.Add('3', 3);
            card.Add('4', 4);
            card.Add('5', 5);
            card.Add('6', 6);
            card.Add('7', 7);
            card.Add('8', 8);
            card.Add('9', 9);
            card.Add('V', 10); // Ten
            card.Add('W', 11); // Jack
            card.Add('X', 12); // Queen
            card.Add('Y', 13); // King
            card.Add('Z', 14); // Ace

            hand = new Dictionary<string, int>();
            hand.Add("High Card", 0);
            hand.Add("One Pair", 100);
            hand.Add("Two Pairs", 200);
            hand.Add("Three of a Kind", 300);
            hand.Add("Straight", 400);
            hand.Add("Flush", 500);
            hand.Add("Full House", 600);
            hand.Add("Four of a Kind", 700);
            hand.Add("Straight Flush", 800);
            hand.Add("Royal Flush", 900);
        }

        private bool Player1Wins(string plays)
        {
            string play1 = plays.Substring(0, 15);
            string play2 = plays.Substring(15);
            int play1Value = Eval(ref play1);
            int play2Value = Eval(ref play2);

            if (play1Value > play2Value)
            {
                if (play1Value > 0 && play2Value > 0)
                {
                    Console.WriteLine(play1 + " > " + play2);
                }
                return true;
            }
            else
            {
                if (play1Value < play2Value)
                {
                    if (play1Value > 0 && play2Value > 0)
                    {
                        Console.WriteLine(play1 + " < " + play2);
                    }
                }
                return false;
            }
        }

        private int Eval(ref string playString)
        {
            List<string> play = new List<string>();
            foreach (string p in playString.Split(' '))
            {
                if (p != "")
                {
                    play.Add(p);
                }
            }
            play.Sort();

            string sortedPlay = "";
            foreach (string p in play)
            {
                sortedPlay += p + " ";
            }
            playString = sortedPlay;

            if (play[0][1] == play[1][1]
                && play[0][1] == play[2][1]
                && play[0][1] == play[3][1]
                && play[0][1] == play[4][1])
            {
                // Royal Flush
                if (play[0][0] == 'V'
                    && play[1][0] == 'W'
                    && play[2][0] == 'X'
                    && play[3][0] == 'Y'
                    && play[4][0] == 'Z')
                {
                    return hand["Royal Flush"];
                }
                // Straight Flush
                else if (
                    card[play[0][0]] + 1 == card[play[1][0]]
                    && card[play[0][0]] + 2 == card[play[2][0]]
                    && card[play[0][0]] + 3 == card[play[3][0]]
                    && card[play[0][0]] + 4 == card[play[4][0]]
                    )
                {
                    return hand["Straight Flush"] + card[play[4][0]];
                }
                // Regular Flush
                else
                {
                    return hand["Flush"] + card[play[4][0]];
                }
            }
            else
            {
                // Four of a Kind
                if (play[1][0] == play[2][0] && play[2][0] == play[3][0] &&
                    (play[0][0] == play[1][0] || play[3][0] == play[4][0]))
                {
                    return hand["Four of a Kind"] + card[play[1][0]];
                }
                // Full House
                else if (play[0][0] == play[1][0] && play[1][0] == play[2][0] && play[3][0] == play[4][0])
                {
                    return hand["Full House"] + 10 * card[play[2][0]] + card[play[4][0]];
                }
                else if (play[0][0] == play[1][0] && play[2][0] == play[3][0] && play[3][0] == play[4][0])
                {
                    return hand["Full House"] + 10 * card[play[2][0]] + card[play[0][0]];
                }
                // Straight
                else if (card[play[0][0]] + 1 == card[play[1][0]]
                    && card[play[0][0]] + 2 == card[play[2][0]]
                    && card[play[0][0]] + 3 == card[play[3][0]]
                    && card[play[0][0]] + 4 == card[play[4][0]])
                {
                    return hand["Straight"] + card[play[4][0]];
                }
                // Three of a Kind
                else if (
                    play[0][0] == play[1][0] && play[1][0] == play[2][0]
                    || play[1][0] == play[2][0] && play[2][0] == play[3][0]
                    || play[2][0] == play[3][0] && play[3][0] == play[4][0])
                {
                    return hand["Three of a Kind"] + card[play[2][0]];
                }
                // Two Pairs
                else if (play[0][0] == play[1][0] && play[2][0] == play[3][0])
                {
                    int max = card[play[0][0]] > card[play[3][0]] ? card[play[0][0]] : card[play[3][0]];
                    return hand["Two Pairs"] + max;
                }
                else if (play[0][0] == play[1][0] && play[3][0] == play[4][0])
                {
                    int max = card[play[0][0]] > card[play[4][0]] ? card[play[0][0]] : card[play[4][0]];
                    return hand["Two Pairs"] + max;
                }
                else if (play[1][0] == play[2][0] && play[3][0] == play[4][0])
                {
                    int max = card[play[1][0]] > card[play[4][0]] ? card[play[1][0]] : card[play[4][0]];
                    return hand["Two Pairs"] + max;
                }
                // One Pair
                else if (play[0][0] == play[1][0])
                {
                    return hand["One Pair"] + card[play[0][0]];
                }
                else if (play[1][0] == play[2][0])
                {
                    return hand["One Pair"] + card[play[1][0]];
                }
                else if (play[2][0] == play[3][0])
                {
                    return hand["One Pair"] + card[play[2][0]];
                }
                else if (play[3][0] == play[4][0])
                {
                    return hand["One Pair"] + card[play[3][0]];
                }
                else
                {
                    // High Card
                    int max = 0;
                    for (int i = 0; i < play.Count; i++)
                    {
                        if(card[play[i][0]] > max) {
                            max = card[play[i][0]];
                        }
                    }
                    return hand["High Card"] + max;
                }

            }
        }

        public string Run()
        {
            int count = 0;

            try
            {
                using (StreamReader sr = new StreamReader("Input/p054_poker.txt"))
                {
                    string both_hands = "";
                    int i = 0;
                    do
                    {
                        both_hands = sr.ReadLine();
                        if (both_hands.Length > 15)
                        {
                            both_hands = both_hands.Replace("T", "V").Replace("J", "W").Replace("Q", "X").Replace("K", "Y").Replace("A", "Z");

                            if (Player1Wins(both_hands))
                            {
                                count++;
                            }
                        }
                        i++;
                    }
                    while (i<1000);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            return count.ToString();
        }
    }
}
