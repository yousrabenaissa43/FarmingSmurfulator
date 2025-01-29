using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmingSmurfulator.Stats
{
    public class OrderSmurfs
    {
        public static int[] OrderPlayers(int[] playersLevel) 
        {
            int[] players = new int[playersLevel.Length];
            int j = 0; 
            for (int i = 0; i < (playersLevel.Length / 2); i++)
            {
                players[j] = playersLevel[i];
                players[j + 1] = playersLevel[playersLevel.Length - 1 - i];

                j += 2; 
            }


            return players;
        }
    }
}
