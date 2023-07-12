using Bogus;
using PersonsProject.Models;

namespace PersonsProject.Test.DataGenerators
{
    /// <summary>
    /// Provides methods for creating fake data related to <see cref="Player"/> objects.
    /// </summary>
    public class PlayerGenerator
    {
        private readonly Faker<Player> _playerFaker;

        /// <summary>
        /// Constructor for <see cref="PlayerGenerator"/>.
        /// </summary>
        public PlayerGenerator()
        {
            var playerFaker = new Faker<Player>()
                .RuleFor(t => t.Name, f => f.Person.FullName)
                .RuleFor(t => t.Age, f => f.Random.Number(1, 40))
                .RuleFor(t => t.Experience, f => f.Random.Number(1, 20))
                .RuleFor(t => t.Skills, new List<int>());

            _playerFaker = playerFaker;
        }

        /// <summary>
        /// Generates a fake <see cref="Player"/> object.
        /// </summary>
        /// <returns>A fake Player object.</returns>
        public Player CreatePlayer()
        {
            return _playerFaker.Generate();
        }
    }
}
