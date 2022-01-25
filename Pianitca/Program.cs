using System;

namespace Pianitca
{
    class Program
    {

        internal static List<Cards> cards = new List<Cards>();
        static void Main()
        {
            Console.Write("Welcome to the game Pianitca(Drunk in Russian) !\n" +
                "Please enter your name:");
            Player one = new Player();
            Player two = new Player();
            one.NameSet(Console.ReadLine());
            two.NameSet("Computer");
            CreateCards();          
            MixCards(one, two);
            Play(one, two);
            
        }

        static void Play(Player one, Player two)
        {
            bool doubles = false;
            while (true)
            {                
                Console.WriteLine("-----------------------------------------\n" +
                    "Please press a key to pull cards ");
                Console.ReadKey();
                Cards oneCard = one.GetCards();                
                Cards twoCard = two.GetCards();

                if (oneCard.Value() > twoCard.Value())
                {
                    Console.WriteLine($"---------------------------------------------------\n" +
                        $"{one.NameGet()} pulled {oneCard.DisplayCard()} and its Bigger then the card of {two.NameGet()} {twoCard.DisplayCard()}");
                    two.SetCards(oneCard);
                    two.SetCards(twoCard);
                    if (doubles)
                    {
                        IfDoubles(two);
                        doubles = false;
                    }
                } else if ( oneCard.Value() < twoCard.Value())
                {
                    Console.WriteLine($"---------------------------------------------------\n" +
                        $"{one.NameGet()} pulled {oneCard.DisplayCard()} and its Smaller then the card of {two.NameGet()} {twoCard.DisplayCard()}");
                    one.SetCards(oneCard);
                    one.SetCards(twoCard);
                    if (doubles)
                    {
                        IfDoubles(one);
                        doubles = false;
                    }
                }
                else if (oneCard.Value() == twoCard.Value())
                {
                    Console.WriteLine($"---------------------------------------------------\n" +
                        $"{one.NameGet()} pulled {oneCard.DisplayCard()} and its same value then the card of {two.NameGet()} {twoCard.DisplayCard()}");
                    cards.Add(oneCard);
                    cards.Add(twoCard);
                    doubles = true;
                }
            }            
        }
        
        public static void IfDoubles( Player loser) 
        {
            Console.WriteLine($"{loser.NameGet()} you also pick up cards from previus game !");
            for (int i = 0; i < cards.Count; i++)
            {

                loser.SetCards(cards[i]);
            }
            cards.Clear();
        }

        static void CreateCards()
        {
            for (int i = 0; i < 4; i++)
            {                
                for (int j = 0; j < 9; j++)
                {
                    Cards newCard = new Cards();
                    newCard.CreateCard(i,j);
                    cards.Add(newCard);
                }
            }
        }
        static void MixCards(Player one, Player two)
        {
            int player = 0;
            while (true)
            {
                Random rand = new Random();
                int index = rand.Next(cards.Count);
                if (cards.Count == 0)
                {
                    return;
                } else if ( player == 0)
                {
                    one.SetCards(cards[index]);
                    cards.RemoveAt(index);
                    player++;
                }
                else if (player == 1)
                {
                    two.SetCards(cards[index]);
                    cards.RemoveAt(index);
                    player--;
                }
            }
        }




    }
}