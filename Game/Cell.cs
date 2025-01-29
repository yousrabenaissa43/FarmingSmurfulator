using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarmingSmurfulator.Game.Items;

namespace FarmingSmurfulator.Game
{
    public class Cell
    {
        public bool IsFree { get; set; }
        public bool IsIrrigated {  get; set; }
        public Occupant Occupant { get; set; }

        public Cell()
        {
            IsFree =true;
            IsIrrigated = false;
            this.Occupant = null;
        }
    }
}
