using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FarmingSmurfulator.Game.Items
{
    public class Plant : Occupant
    {
       public string Name {  get; private set; }
       public int GrowthDays { get; set; }
       public int SellingPrice {  get; }

        public Plant(string name, int growthDays, int sellingPrice, int BuyingPrice) : base(BuyingPrice)
        {
            if (name != "Wheat" && name != "Saffron")
            {
                throw new ArgumentException("Name must be either 'Wheat' or 'Saffron'.");
            }
            GrowthDays = growthDays;
            SellingPrice = sellingPrice;
        }

        public bool IsMature()
        {
            if (GrowthDays <= 0) {  return true ; }
            else { return false ; } 
        }

    }
    
    }
