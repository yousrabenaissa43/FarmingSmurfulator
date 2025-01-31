
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
        //Console.WriteLine(((Plant)b4.Grid[0, 0].Occupant).GrowthDays);
        b4.UpdateGrowthDays();
        // Console.WriteLine(((Plant)b4.Grid[0, 0].Occupant).GrowthDays);


        //testing Player buyWell
        char[,] c3 = new char[2, 2]
        {
            { '-', '-' },
            { '-', 'x' }
         };
        Player p3 = new Player(c3, "Smurf", 150); // ActionQueue == { } 
        //Console.WriteLine(p3.DisplayInfo());

        bool well1 = p3.BuyWell(0, 1);   // ActionQueue == { { "buy", "Well", "0", "1" } } 
        //Console.WriteLine(well1);        // well1 == true 
        //Console.WriteLine(p3.DisplayInfo());

        bool well2 = p3.BuyWell(1, 1);   // ActionQueue == { { "buy", "Well", "0", "1" } } 
        //Console.WriteLine(well2);        // well2 == false 
        //Console.WriteLine(p3.DisplayInfo());

        //testing collect method in Player 

        char[,] c5 = new char[2, 2]
            {
              { '-', 'W' },
              { '-', '-' }
             };
        Player p5 = new Player(c5, "Smurf", 150);
        //Console.WriteLine(p5.DisplayInfo());
        bool collected1 = p5.TryCollectPlant(0, 1);   // ActionQueue == { { "collect", "0", "1" } } 
        //Console.WriteLine(collected1);
        // collected1 == true 
        //Console.WriteLine(p5.DisplayInfo());

        //testing CancelFirstAction 

        char[,] c6 = new char[2, 2]
           {
             { '-', '-' },
             { '-', '-' }
           };
        Player p6 = new Player(c6, "Smurf", 150);
        p6.BuySeed("Wheat");    // ActionQueue == { { "buy", "Wheat" } } 
        p6.BuySeed("Saffron");  // ActionQueue == { { "buy", "Wheat" }, { "buy", "Saffron" } } 
        //Console.WriteLine(p6.DisplayInfo());
        p6.CancelFirstAction(); // ActionQueue == { { "buy", "Saffron" } } 
        //Console.WriteLine(p6.DisplayInfo());


        //testing class Stonks 


        List<(string, int)> ratings = new List<(string, int)>
    {
    ("HoloSmurf", 5),
    ("HoloSmurf", 3),
    ("League of Smurfs", 2),
    ("HoloSmurf", 4),
    ("Garry's Smurf", 5),
    ("Garry's Smurf", 0),
    ("Counter Smurf, Global Offensive", 3),
    ("Counter Smurf, Global Offensive", 4),
    ("Counter Smurf, Global Offensive", 4),
    ("Counter Smurf, Global Offensive", 2),
     };
        Dictionary<string, List<int>> groupRating = Stonks.GroupRatings(ratings);
        //
        Dictionary<string, List<int>> groupRating2 = new Dictionary<string, List<int>>();
        groupRating2.Add("HoloSmurf", new List<int>() { 5, 3, 4 });
        groupRating2.Add("League of Smurfs", new List<int>() { 2 });
        groupRating2.Add("Garry's Smurf", new List<int>() { 5, 0 });
        groupRating2.Add("Counter Smurf, Global Offensive", new List<int>() { 3, 4, 4, 2 });
        Dictionary<string, double> computed = Stonks.ComputeBayesianRating(3, groupRating2);

        //tesing print board 

        Board b5 = new Board(5);
        string map1 = b5.PrintBoard();
        Console.WriteLine("Map 1");
        Console.WriteLine(map1);
        b5.AddWell(1, 3);
        b5.AddWell(4, 0);
        string map2 = b5.PrintBoard();
        Console.WriteLine("Map 2");
        Console.WriteLine(map2);

        b5.AddSeed("Wheat");
        //Console.WriteLine(b5.AddSeed("Wheat"));
        b5.PlantSeed("Wheat", 0, 2);
        string map3 = b5.PrintBoard();
        Console.WriteLine("Map 3");
        Console.WriteLine(map3);

        b5.UpdateGrowthDays();
        b5.UpdateGrowthDays();
        b5.UpdateGrowthDays();
        string map4 = b5.PrintBoard();
        Console.WriteLine("Map 4");
        Console.WriteLine(map4);
    }
    



}
