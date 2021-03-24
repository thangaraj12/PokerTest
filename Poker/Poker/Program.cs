using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Poker
{
    class Program
    {
        static void Main(string[] args)
        {
            Card[] deck = new Card[52]; // create deck
            Card[] hand1 = new Card[5];
            Card[] hand2 = new Card[5];
            Card[] hand3 = new Card[5];
            Card[] hand4 = new Card[5];
            Random rnd = new Random();
            string handValue = "";
            int rand1 = 0, rand2 = 0, rand3 = 0, temp = 0;
            int[] holdRandomNum = new int[52]; 
            string suit = "";
            int value = 0;
            int iterator = 0; // used to iterate until 52
            for ( int i = 0; i < 4; i++)
            {
                switch(i)
                {
                    case 0:
                        suit = "Diamonds";
                        break;
                    case 1:
                        suit = "Clubs";
                        break;
                    case 2:
                        suit = "Hearts";
                        break;
                    case 3:
                        suit = "Spades";
                        break;
                }
                for ( int j = 1; j < 14; j++)
                {
                    deck[iterator] = new Card(suit, j+1);
                    iterator++;
                }
            }
            for ( int i = 0; i < 52; i++)
            {
                Console.WriteLine(deck[i].getCard());
            }

            for (int i = 0; i < holdRandomNum.Length; i++)
            {
                holdRandomNum[i] = i;
            }
            for (int i = 0; i < holdRandomNum.Length; i++)
            {
                rand1 = rnd.Next(0, 52);
                rand2 = rnd.Next(0, 52);
                rand3 = rnd.Next(0, 52);
                if ( rand1 == rand2)
                {
                   rand2 = rnd.Next(0, 52);
                }
                if ( rand2 == rand3)
                {
                    rand3 = rnd.Next(0, 52);
                }
                if ( rand1 == 3)
                {
                    rand1 = rnd.Next(0,52);
                }
                temp = holdRandomNum[i];
                holdRandomNum[i] = holdRandomNum[rand1];
                holdRandomNum[rand1] = holdRandomNum[rand2];
                holdRandomNum[rand2] = holdRandomNum[rand3];
                holdRandomNum[rand3] = temp;
            }

            for (int i = 0; i < holdRandomNum.Length; i++)
            {
                Console.WriteLine(holdRandomNum[i]);
            }
            iterator = 0;
            for ( int i = 0; i < 4; i++)
            {
                for ( int j = 0; j < 5; j++)
                {
                    switch(i)
                    {
                        case 0:
                            hand1[j] = deck[holdRandomNum[iterator]];
                            break;
                        case 1:
                            hand2[j] = deck[holdRandomNum[iterator]];
                            break;
                        case 2:
                            hand3[j] = deck[holdRandomNum[iterator]];
                            break;
                        case 3:
                            hand4[j] = deck[holdRandomNum[iterator]];
                            break;
                    }
                    iterator++;
                }
            }
            for (int i =0; i< 5; i++)
            {
                Console.WriteLine("1 "+hand1[i].getCard());
            }
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("2 " + hand2[i].getCard());
            }
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("3 " + hand3[i].getCard());
            }

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("4 " + hand4[i].getCard());
            }
            int[] hands = new int[] { getValueOfHand(hand1,ref handValue), getValueOfHand(hand2,ref handValue), getValueOfHand(hand3,ref handValue), getValueOfHand(hand4,ref handValue) };
            int maxHand = hands.Max();
            int index = hands.ToList().IndexOf(maxHand);
            index += 1;
            Console.WriteLine("Hand " + index +" Had the best hand with a"+ handValue);
        }

        public static int getValueOfHand(Card[] c, ref string str)
        {
            //string str = "";
            int val = 0;
            List<int> holdVal = new List<int>();
            List<string> holdSuit = new List<string>();
            for (int i = 0; i< 5; i++)
            {
                holdVal.Add(c[i].getValue());
                holdSuit.Add(c[i].getSuit());

            }

            holdVal.Sort();
            bool isStraight = Enumerable.Range(holdVal.ElementAt(0), 5).SequenceEqual(holdVal);
            bool sameSuit = holdSuit.All(p => p == holdSuit.ElementAt(0));
            bool isRoyal = Enumerable.Range(10, 5).SequenceEqual(holdVal);
            int temp = holdVal.ElementAt(0);
            bool isPair = false;
            bool isTriple = false;
            int[] pairCount = new int[3]; // 
            int pairIterate = 0;
            bool four = false;
            List<int> pair = new List<int>();
            //int oldValue = holdVal.ElementAt(0);
            for (int i = 0; i < 5; i++)
            {
                if (i != 4)
                {
                    if (holdVal.ElementAt(i) == holdVal.ElementAt(i + 1))
                    {
                        pairCount[pairIterate] = holdVal.ElementAt(i);
                        pairIterate++;
                        isPair = true;

                    }
                }


            }
            pair = pairCount.ToList(); ;

            string bla = "ye";
            if ( pairCount.ElementAt(0) != 0)
            { 
                bool hasPair = pairCount.Any(p => p != 0);
                four = pairCount.All(p => p == pairCount[0]);
            }
            pair.RemoveAll(p => p == 0);



            if ( isRoyal && sameSuit)
            {
                str = " a royal Flush";
                val = 10;
                return val;
            }else
            if (sameSuit && isStraight)
            {
                str = " a straight flush";
                val = 9;
                return val;
            }else
            if (four)
            {
                str = " a Four of a kind";
                val = 8;
                return val;
            }else
            if (pair.Count == 3)
            {
                if (pair.ElementAt(0) == pair.ElementAt(1))
                {
                    str = " a triple " + pair.ElementAt(0) + " and a pair of " + pair.ElementAt(2);
                    val = 7;
                    return val;
                }
                else
                {
                    str = " a triple " + pair.ElementAt(1) + " and a Pair of " + pair.ElementAt(0);
                    val = 7;
                    return val;
                }
            }else
            if (sameSuit)
            {
                str = " a flush";
                val = 6;
                return val;
            }
            else
            if ( isStraight)
            {
                str = " a Straght";
                val = 5;
                return val;
            }
            else
            if (pair.Count == 2)
            {
                isTriple = pair.All(p => p == pair.ElementAt(0));
                if (isTriple)
                {
                    str = " a triple " + pair.ElementAt(0);
                    val = 4;
                    return val;
                }
                else
                {
                    str = " a pair of " + pair.ElementAt(0) + " and a Pair of " + pair.ElementAt(1);
                    val = 3;
                    return val;
                }

            }else
            if (pair.Count == 1)
            {
                str = " a Pair of " + pairCount.ElementAt(0);
                val = 2;
                return val;
            }


            // PAIR






            return val;
        }
    }

}
