namespace Blackjack_peli;

public class Deck
{
    public List<Card> Cards = new List<Card>();

    
    private void InitializeSuit(string s)
    {
        for (int i = 2; i <= 14; i++)
        {
            var card = new Card();
            card.Rank = i;
            card.Suit = s;
            this.Cards.Add(card);
        }   
    }

    public Deck()
    {
        this.InitializeSuit("Spades");
        this.InitializeSuit("Clubs");
        this.InitializeSuit("Diamonds");
        this.InitializeSuit("Hearts");
    }

    public void Shuffle(int iterations)
    {
        for (int i = 0; i < iterations; i++)
        {
            var s = new Random().Next(0, 52);       
            var n = new Random().Next(0, 52);       
            var temp = this.Cards[s];               
            this.Cards[s] = this.Cards[n];          
            this.Cards[n] = temp;                      
        }
    }

    public List<Card> Deal(int numberOfCards)
    {
        List<Card> result = new List<Card>();
        for (int i = 0; i < numberOfCards; i++)
        {
            result.Add(this.Cards[0]);
            this.Cards.RemoveAt(0);
        }
        
        return result;
    }
}