using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using FarmingSmurfulator.Game.Items;

namespace FarmingSmurfulator.Game
{
    public class Board
    {
        public Cell[,] Grid {  get; private set; }
        public Dictionary<string, int> Seeds;

        public Board(int size) 
        {
            if (size > 0)
            {
                Grid = new Cell[size, size];
                Seeds = new Dictionary<string, int>
                     {
                       { "Wheat", 0 },
                       { "Saffron", 0 }
                     };

                // Initialisation des cellules de la grille
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        Grid[i, j] = new Cell(); // Ajout de l'initialisation
                    }
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("matrix size must be > 0 ");
            }
        }
        public bool AddWell(int x, int y) 
        {
            if (x < 0 || x >= Grid.Length || y < 0 || y >= Grid.Length )
            {
                return false;
            }
            if (!Grid[x, y].IsFree)
            {
                return false;
            }

            Grid[x, y].IsFree = false;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    int newX = x + i;
                    int newY = y + j;

                    // Vérifie si la cellule est dans les limites avant de l'irriguer
                    if (newX >= 0 && newX < Grid.Length && newY >= 0 && newY < Grid.Length)
                    {
                        Grid[newX, newY].IsIrrigated = true;
                    }
                }
            }

            return true;
        }

        public bool AddSeed(string seed) 
        {
            if (Seeds.ContainsKey(seed))
            {
                Seeds[seed]++; 
                return true;
            }
            return false; 
        }

        public bool PlantSeed(string seed, int x, int y)
        { 
         if(!Seeds.ContainsKey(seed) || x >= Grid.Length || y >= Grid.Length) return false;
         if (!Grid[x,y].IsIrrigated) return false;

         Cell cell = Grid[x,y];
         cell.IsFree = false;
         if (seed == "Wheat")
            {
                cell.Occupant = new Plant("Wheat",3,20,10); 
                
            }
         if (seed == "Saffron")
            {
                cell.Occupant = new Plant("Saffron",5,42, 25);
            }
         return true ;
        }
       public void UpdateGrowthDays() 
        {
            foreach (Cell cell in Grid)
            {
                if (cell.Occupant is Plant)
                {
                    ((Plant)cell.Occupant).GrowthDays -= 1;
                }
            }
        }
    }
}
