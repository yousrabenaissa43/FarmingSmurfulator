using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmingSmurfulator.Stats
{
    public class Stonks
    {
        public static Dictionary<string, List<int>> GroupRatings(List<(string, int)> ratings)
        {
            Dictionary<string, List<int>> groupedRatings = new Dictionary<string, List<int>>();

            foreach (var (game, rating) in ratings)
            {
                if (!groupedRatings.ContainsKey(game))
                {
                    groupedRatings[game] = new List<int>();
                }
                groupedRatings[game].Add(rating);
            }

            return groupedRatings;
        }

        public static Dictionary<string, double> ComputeBayesianRating(uint c, Dictionary<string, List<int>> groupedRatings)
        {
            Dictionary<string, double> bayesianRatings = new Dictionary<string, double>();

            foreach (var entry in groupedRatings)
            {
                string game = entry.Key;
                List<int> ratings = entry.Value;

                double totalStars = ratings.Sum();
                double numReviews = ratings.Count;

                double bayesianAvg = Math.Round((c * 2.5 + totalStars) / (c + numReviews), 5);
                bayesianRatings[game] = bayesianAvg;
            }

            return bayesianRatings;
        }

        public static List<string> GetMostPopular(uint firsts, Dictionary<string, double> games)
        {
            return games.OrderByDescending(g => g.Value)   // Sort by rating (highest first)
                        .Take((int)firsts)  // Take the top 'firsts' games
                        .Select(g => g.Key)  // Get only the game names
                        .ToList(); // Convert to a list
        }

    }
}
