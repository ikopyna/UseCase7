namespace PersonsProject.Models
{
    /// <summary>
    /// Represents a player.
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Gets or sets the name of the player.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the age of the player.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Gets or sets the experience of the player.
        /// </summary>
        public int Experience { get; set; }

        /// <summary>
        /// Gets or sets the skill list of the player.
        /// </summary>
        public List<int> Skills { get; set; }
    }
}
