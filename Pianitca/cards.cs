using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pianitca
{
    public class Cards
    {
        private int value;

        private int suit;
                                        //0    1    2    3
        private string[] suitDisplay = { "♣", "♦", "♥", "♠" };
                                        // 0    1    2    3    4     5       6        7       8
        private string[] valueDisplay = { "6", "7", "8", "9", "10", "Jack", "Queen", "King", "ACE" };

        public void CreateCard(int suit, int value)
        {
            this.suit = suit;
            this.value = value;
        }

        public string DisplayCard()
        {
            string Display = "|" + suitDisplay[suit] + valueDisplay[value]+ "|";

            return Display;
        }

        public int Value() { return value; }
        public int Suit() { return suit;}
        
    }
}
