using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Use_Case_.Net_Nazarii_Ivasyshyn.Tests
{
  public class PlayerTests
  {
    private PlayerAnalyzer _analyzer;

    public PlayerTests()
    {
      _analyzer = new PlayerAnalyzer();
    }

    [Fact]
    public void Normal_Player()
    {
      // Arrange
      Player player = new Player
      {
        Age = 25,
        Experience = 5,
        Skills = new List<int> { 2, 2, 2 }
      };
      List<Player> players = new List<Player> { player };

      // Act
      var result = _analyzer.CalculateScore(players);

      // Assert
      Assert.Equal(250, result);
    }

    [Fact]
    public void Junior_Player()
    {
      // Arrange
      Player player = new Player
      {
        Age = 15,
        Experience = 3,
        Skills = new List<int> { 3, 3, 3 }
      };
      List<Player> players = new List<Player> { player };

      // Act
      var result = _analyzer.CalculateScore(players);

      // Assert
      Assert.Equal(67.5, result);
    }

    [Fact]
    public void Senior_Player()
    {
      // Arrange
      Player player = new Player
      {
        Age = 35,
        Experience = 15,
        Skills = new List<int> { 4, 4, 4 }
      };
      List<Player> players = new List<Player> { player };

      // Act
      var result = _analyzer.CalculateScore(players);

      // Assert
      Assert.Equal(2520, result);
    }

    [Fact]
    public void Multiple_Players()
    {
      // Arrange
      Player player1 = new Player
      {
        Age = 25,
        Experience = 5,
        Skills = new List<int> { 2, 2, 2 }
      };

      Player player2 = new Player
      {
        Age = 15,
        Experience = 3,
        Skills = new List<int> { 3, 3, 3 }
      };

      Player player3 = new Player
      {
        Age = 35,
        Experience = 15,
        Skills = new List<int> { 4, 4, 4 }
      };

      List<Player> players = new List<Player> { player1, player2, player3 };
      List<Player> players1 = new List<Player> { player1 };
      List<Player> players2 = new List<Player> { player2 };
      List<Player> players3 = new List<Player> { player3 };

      // Act
      var result = _analyzer.CalculateScore(players);
      var result1 = _analyzer.CalculateScore(players1);
      var result2 = _analyzer.CalculateScore(players2);
      var result3 = _analyzer.CalculateScore(players3);

      // Assert
      Assert.Equal(result, result1 + result2 + result3);
    }

    [Fact]
    public void Skills_Is_Null()
    {
      // Arrange
      Player player = new Player
      {
        Age = 35,
        Experience = 15,
      };
      List<Player> players = new List<Player> { player };

      // Act, Assert
      ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => _analyzer.CalculateScore(players));
    }

    [Fact]
    public void Empty_Array()
    {
      // Arrange
      List<Player> players = new List<Player>();

      // Act
      var result = _analyzer.CalculateScore(players);

      // Assert
      Assert.Equal(0, result);
    }
  }
}
