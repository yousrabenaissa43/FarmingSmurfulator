
namespace FarmingSmurfulator.Game.Items
{
    public class Occupant
    {
        public int BuyingPrice {  get; }
        public Occupant(int buyingPrice)
        {
            if (buyingPrice < 0)
            {
                BuyingPrice = 0;
            }
            else
            {
                BuyingPrice = buyingPrice;
            }
        }
    }
}
