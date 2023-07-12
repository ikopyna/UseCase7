using PersonsProject.Models;

namespace PersonsProject.Analyzers
{
    /// <summary>
    /// Provides methods for analyzing and calculating data related to <see cref="Player"/> objects.
    /// </summary>
    public class PlayerAnalyzer
    {
        /// <summary>
        /// Processes a list of given <see cref="Player"/> objects and returns the calculated score.
        /// </summary>
        /// <param name="players">The list of Player objects to process.</param>
        /// <returns>An overall score.</returns>
        public double CalculateScore(List<Player> players)
        {
            double score = 0;

            foreach (var player in players)
            {
                double skillsAverage = player.Skills.Sum() / (double)player.Skills.Count;
                double contribution = player.Age * player.Experience * skillsAverage;

                if (player.Age < 18)
                {
                    contribution *= 0.5;
                }

                if (player.Experience > 10)
                {
                    contribution *= 1.2;
                }

                score += contribution;
            }

            return score;
        }
    }
}