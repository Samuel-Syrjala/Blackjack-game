using System.ComponentModel.Design;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Blackjack_peli;

internal class Program
{
    private static void Main(string[] args)
    {
        var deck1 = new Deck();
        deck1.Shuffle(1000);

        List<int> HandValues(List<Card> list)
        {
            var handValuesList = new List<int>();
            foreach (var card in list) handValuesList.Add(card.GetValue());
            return handValuesList;
        }

        bool gameOver = false;
        while (gameOver == false)
        {
            var hand1 = deck1.Deal(2);
            var dealerHand = deck1.Deal(2);
            
            Console.WriteLine("Hand 1:");
            Thread.Sleep(2000);
            foreach (var card in hand1)
            {
                Console.WriteLine(card.Rank + " of " + card.Suit);
                Thread.Sleep(2000);
            }
            Console.WriteLine("Hand value is: " + HandValues(hand1).Sum());
            Console.WriteLine("");

            if (HandValues(hand1).Sum() == 21 && HandValues(dealerHand).Sum() != 21)
            {
                Console.WriteLine("You have Blackjack!");
                return;
            }

            Thread.Sleep(2000);
            Console.WriteLine("Dealer has: " + dealerHand[0].Rank + " of " + dealerHand[0].Suit);
            Thread.Sleep(2000);
            
            if (HandValues(dealerHand).Sum() == 21)
            {
                Console.WriteLine(dealerHand[1].Rank + " of " + dealerHand[1].Suit);
                Console.WriteLine("Dealer has Blackjack!");
                return;
            }

            while (HandValues(hand1).Sum() < 21)
            {
                Console.WriteLine("Stand or hit?");
                Console.WriteLine("");
                var input = Console.ReadLine();
                if (input == "hit" || input == "Hit")
                {
                    Console.WriteLine("Dealing...");
                    Thread.Sleep(2000);
                    hand1.AddRange(deck1.Deal(1));
                    Console.WriteLine(hand1[hand1.Count - 1].Rank + " of " + hand1[hand1.Count - 1].Suit);
                    if (HandValues(hand1).Contains(11) && HandValues(hand1).Sum() > 21)
                    {
                        foreach (var card in hand1)
                        {
                            if (card.GetValue() == 11)
                            {
                                card.Rank = 1;
                                Console.WriteLine(HandValues(hand1).Sum());     
                            }
                        }
                    }
                    Console.WriteLine("Hand value is: " + HandValues(hand1).Sum());
                }
                else if (input == "Stand" || input == "stand")
                {
                    Console.WriteLine("Dealer's turn...");
                    Thread.Sleep(2000);
                    break;
                }
                else
                {
                    Console.WriteLine("You must either stand or hit.");
                    Thread.Sleep(2000);
                }
            }

            if (HandValues(hand1).Sum() > 21) Console.WriteLine("You have bust!");

            if (HandValues(hand1).Sum() == 21) Console.WriteLine("You have 21!");
            
            Console.WriteLine("Dealer's hand:");
            Thread.Sleep(1500);
            Console.WriteLine(dealerHand[0].Rank + " of " + dealerHand[0].Suit);
            Thread.Sleep(1500);
            Console.WriteLine(dealerHand[1].Rank + " of " + dealerHand[1].Suit);

            while (HandValues(dealerHand).Sum() < 17)
            {
                Thread.Sleep(1500);
                Console.WriteLine("Dealer's hand value is : " + HandValues(dealerHand).Sum());
                Thread.Sleep(1500);
                dealerHand.AddRange(deck1.Deal(1));
                Console.WriteLine(dealerHand[dealerHand.Count - 1].Rank + " of " + dealerHand[dealerHand.Count - 1].Suit);
                if (HandValues(dealerHand).Contains(11) && HandValues(dealerHand).Sum() > 21)
                {
                    foreach (var card in dealerHand)
                    {
                        if (card.GetValue() == 11)
                        { 
                            card.Rank = 1;    
                        }
                    }
                }
            }

            Thread.Sleep(2000);
            if (HandValues(dealerHand).Sum() > 21) Console.WriteLine("Dealer has bust!");

            if (HandValues(dealerHand).Sum() == 21) Console.WriteLine("Dealer has 21.");

            if (HandValues(dealerHand).Sum() > HandValues(hand1).Sum() && HandValues(dealerHand).Sum() <= 21)
                Console.WriteLine("Dealer wins!");
            else if (HandValues(dealerHand).Sum() < HandValues(hand1).Sum() && HandValues(hand1).Sum() <= 21)
                Console.WriteLine("You win!");
            if (HandValues(dealerHand).Sum() == HandValues(hand1).Sum()) Console.WriteLine("Push.");
            
            bool noTypo = false;                                             
            while (noTypo == false)                                          
            {                                                                
                Console.WriteLine("Continue game Y/N?");                     
                var input2 = Console.ReadLine();                             
                if (input2 == "Y" || input2 == "y" || input2 == "Yes"|| input2 == "yes")      
                {                                                            
                    gameOver = false;                                        
                    noTypo = true;
                    Thread.Sleep(2000);
                    break;
                }                                                            
                if (input2 == "N" || input2 == "n" || input2 == "No"|| input2 == "no")        
                {                                                            
                    gameOver = true;                                         
                    noTypo = true;
                    Thread.Sleep(2000);
                    break;
                }                                                            
                else                                                         
                {                                                            
                    noTypo = false;                                          
                }                                                            
            }                                                                
        }
    }
}