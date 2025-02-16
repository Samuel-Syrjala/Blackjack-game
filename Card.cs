using System.ComponentModel.Design;

namespace Blackjack_peli;
public class Card
{
    public string Suit;
    public int Rank;
    
    public int GetValue()
    {
        int Value;
        if (1<=this.Rank && 10>=this.Rank)
        {
            Value = this.Rank;
        }
        else if (this.Rank == 14)
        {
            Value = 11;
        }
        else
        {
            Value = 10;
        }
        
        return Value;
    }
}