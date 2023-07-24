using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Use_Case_.Net_Nazarii_Ivasyshyn
{
  public class Player
  {
    public string Name { get; set; }

    public int Age { get; set; }

    public int Experience { get; set; }

    public List<int> Skills { get; set; }

  }

  public class PlayerAnalyzer
  {
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
