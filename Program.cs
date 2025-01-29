
using FarmingSmurfulator.Game;
using FarmingSmurfulator.Game.Items;
using FarmingSmurfulator.Stats;

public class Test
{
    public static void Main(string[] args)
    {
        //testing OrderSmurfs
        int[] players1 = new int[] { 12, 3, 2, 8, 7, 6 };
        // Console.WriteLine(string.Join(", ", OrderSmurfs.OrderPlayers(players1))); // print an int table without loop 

        //testing board addWell

        Board b1 = new Board(5);
        bool addWell1 = b1.AddWell(0, 1);   // b1.Grid[0, 1].Occupant est un Well 
        bool addWell2 = b1.AddWell(0, 1);   // b1.Grid[0, 1].Occupant est déjà un Well, donc les 


        /* Console.WriteLine(addWell1);
        Console.WriteLine(addWell2);
        Console.WriteLine(b1.Grid[0, 0].IsIrrigated);
        Console.WriteLine(b1.Grid[0, 1].IsIrrigated);
        Console.WriteLine(b1.Grid[0, 1].IsFree); */

        // testing board addSeed

        Board b2 = new Board(5);
        bool addSeed1 = b2.AddSeed("Saffron");         // Seeds == { "Saffron": 1, "Wheat": 0 } 
        //Console.WriteLine(addSeed1);
        bool addSeed2 = b2.AddSeed("Wheat");           // Seeds == { "Saffron": 1, "Wheat": 1 } 
        //Console.WriteLine(addSeed2);
        bool addSeed3 = b2.AddSeed("Piranha Plant");   // Seeds == { "Saffron": 1, "Wheat": 1 } 
        //Console.WriteLine(addSeed3);

        //testing PlantSeed

        Board b3 = new Board(5);
        b3.AddSeed("Saffron");                             // Seeds == { "Saffron": 1, "Wheat": 0 } 
        bool notPlanted = b3.PlantSeed("Saffron", 0, 0);   // Seeds == { "Saffron": 1, "Wheat": 0 } 
        /*Console.WriteLine(notPlanted);
        Console.WriteLine(b3.Grid[0, 0].Occupant is Plant);
        Console.WriteLine(b3.Grid[0, 0].IsFree);*/
        b3.AddWell(1, 1);
        bool planted = b3.PlantSeed("Saffron", 0, 0);      // Seeds == { "Saffron": 0, "Wheat": 0 } 
        /*Console.WriteLine(planted);
        Console.WriteLine(b3.Grid[0, 0].Occupant is Plant);
        Console.WriteLine(b3.Grid[0, 0].IsFree);*/

        //testing UpdateGrowthDays
        Board b4 = new Board(5);
        b4.AddSeed("Saffron");   // Seeds == { "Saffron": 1, "Wheat": 0 } 
        b4.AddWell(1, 1);
        b4.PlantSeed("Saffron", 0, 0);
        Console.WriteLine(((Plant)b4.Grid[0, 0].Occupant).GrowthDays);
        b4.UpdateGrowthDays();
        Console.WriteLine(((Plant)b4.Grid[0, 0].Occupant).GrowthDays);

    }

}
