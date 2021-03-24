using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Poker
{
    class Card
    {
        private int value = 0; // value of card NOTE:  11 = jack, 12 = queeen, 13 = king 14 = ace
        private string suit = ""; // suit of card 

        public Card(string s, int v) // creat card
        {
            suit = s;
            value = v;
        }

        public string getSuit()
        {
            return suit;
        }
        public int getValue()
        {
            return value;
        }
        public void setValue(int v)
        {
            value = v;
        }
        public string getCard()
        {
            string str = value + " of " + suit;
            return str;
        }

    }
}
