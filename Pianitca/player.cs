using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pianitca
{
    public class Player
    {
        private string name;
        private List<Cards> playerCards = new List<Cards>();

        public void NameSet(string name)
        {
            this.name = name;
        }

        public string NameGet()
        {
            return this.name;
        }

        public List<Cards> SeePlayerCards()
        {
            return playerCards;
        }

        public void SetCards(Cards one)
        {
            playerCards.Add(one);
        }

        public Cards GetCards()
        {
            if (playerCards.Count == 0)
            {
                Console.WriteLine($"{this.name} have no more cards , {this.name} have WON !!!!\n" +
                    $"press any key close the program  :)");
                Console.ReadKey();                
                Environment.Exit(0);
                return null;
            } 
            else
            {
                Cards one = playerCards[0];
                playerCards.RemoveAt(0);
                return one;
            }
        }

    }
}
