using PersonsProject.Analyzers;
using PersonsProject.Models;
using PersonsProject.Test.DataGenerators;
using Xunit;

namespace PersonsProject.Test
{
    /// <summary>
    /// Tests for <see cref="PlayerAnalyzer"/>.
    /// </summary>
    public class PlayerAnalyzerTest
    {

        private const int NORMAL_PLAYER_AGE = 25;
        private const int NORMAL_PLAYER_EXPEREINCE = 5;
        private const double NORMAL_PLAYER_CALCULATED_SCORE = 250; // A score of 250 (since 25*5*2 = 250)
        private const int JUNIOR_PLAYER_AGE = 15;
        private const int JUNIOR_PLAYER_EXPEREINCE = 3;
        private const double JUNIOR_PLAYER_CALCULATED_SCORE = 67.5; // A score of 67.5 (since 15*33*0.5 = 67.5)
        private const int SENIOR_PLAYER_AGE = 35;
        private const int SENIOR_PLAYER_EXPEREINCE = 15;
        private const double SENIOR_PLAYER_CALCULATED_SCORE = 2520; // A score of 2520 (since 35*15*4*1.2 = 2520)

        private static readonly List<int> NormalPlayerSkills = new List<int>() { 2, 2, 2 };
        private static readonly List<int> JuniorPlayerSkills = new List<int>() { 3, 3, 3 };
        private static readonly List<int> SeniorPlayerSkills = new List<int>() { 4, 4, 4 };

        private readonly PlayerGenerator _playerGenerator;
        private readonly PlayerAnalyzer _sut;

        /// <summary>
        /// Setup.
        /// </summary>
        public PlayerAnalyzerTest()
        {
            _playerGenerator = new PlayerGenerator();
            _sut = new PlayerAnalyzer();
        }

        /// <summary>
        /// CalculateScore method on giving an empty array, should return 0 
        /// (since there are no players to contribute to the score).
        /// </summary>
        [Fact]
        public void CalculateScore_EmptyArrayInput_ReturnsZero()
        {
            // Arrange
            var emptyPlayersList = new List<Player>();

            // Act
            var result = _sut.CalculateScore(emptyPlayersList);

            // Assert
            Assert.Equal(0, result);
        }


        /// <summary>
        /// CalculateScore method on giving a list with a player where Skills 
        /// property is null, should throw an exception.
        /// </summary>
        [Fact]
        public void CalculateScore_NullSkillsParam_ThrowsException()
        {
            // Arrange
            var testPlayer = _playerGenerator.CreatePlayer();
            testPlayer.Skills = null;

            var playersList = new List<Player>
            {
                testPlayer
            };

            // Act / Assert
            _ = Assert.Throws<ArgumentNullException>(() =>
            {
                _ = _sut.CalculateScore(playersList);
            });
        }

        /// <summary>
        /// CalculateScore method on giving an array with a single player, 
        /// should return a valid result.
        /// </summary>
        [Theory]
        [MemberData(nameof(TestPlayers))]
        public void CalculateScore_SinglePlayerFlow_ReturnsValidScore(int playerAge, int playerExpereince, List<int> playerSkills, double expectedScore)
        {
            // Arrange
            var testPlayer = _playerGenerator.CreatePlayer();
            testPlayer.Age = playerAge;
            testPlayer.Experience = playerExpereince;
            testPlayer.Skills = playerSkills;

            var playersList = new List<Player>
            {
                testPlayer
            };

            // Act
            var result = _sut.CalculateScore(playersList);

            // Assert
            Assert.Equal(expectedScore, result);
        }

        /// <summary>
        /// CalculateScore method on giving an array with multiple player objects,
        /// should return the sum of their scores.
        /// </summary>
        [Fact]
        public void CalculateScore_MultiplePlayersFlow_ReturnsValidScore()
        {
            // Arrange
            var testNormalPlayer = _playerGenerator.CreatePlayer();
            testNormalPlayer.Age = NORMAL_PLAYER_AGE;
            testNormalPlayer.Experience = NORMAL_PLAYER_EXPEREINCE;
            testNormalPlayer.Skills = NormalPlayerSkills;

            var testJuniorPlayer = _playerGenerator.CreatePlayer();
            testJuniorPlayer.Age = JUNIOR_PLAYER_AGE;
            testJuniorPlayer.Experience = JUNIOR_PLAYER_EXPEREINCE;
            testJuniorPlayer.Skills = JuniorPlayerSkills;

            var testSeniorPlayer = _playerGenerator.CreatePlayer();
            testSeniorPlayer.Age = SENIOR_PLAYER_AGE;
            testSeniorPlayer.Experience = SENIOR_PLAYER_EXPEREINCE;
            testSeniorPlayer.Skills = SeniorPlayerSkills;

            var playersList = new List<Player>
            {
                testNormalPlayer,
                testJuniorPlayer,
                testSeniorPlayer
            };

            var expectedScore = NORMAL_PLAYER_CALCULATED_SCORE + JUNIOR_PLAYER_CALCULATED_SCORE + SENIOR_PLAYER_CALCULATED_SCORE;

            // Act
            var result = _sut.CalculateScore(playersList);

            // Assert
            Assert.Equal(expectedScore, result);
        }

        private static IEnumerable<object[]> TestPlayers()
        {
            return new List<object[]> {
                new object[] { JUNIOR_PLAYER_AGE, JUNIOR_PLAYER_EXPEREINCE, JuniorPlayerSkills, JUNIOR_PLAYER_CALCULATED_SCORE },
                new object[] { NORMAL_PLAYER_AGE, NORMAL_PLAYER_EXPEREINCE, NormalPlayerSkills, NORMAL_PLAYER_CALCULATED_SCORE },
                new object[] { SENIOR_PLAYER_AGE, SENIOR_PLAYER_EXPEREINCE, SeniorPlayerSkills, SENIOR_PLAYER_CALCULATED_SCORE }
              };
        }
    }
}