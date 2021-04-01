namespace Game
{
    public enum WallType
    {
        /// <summary>
        /// No wall.
        /// </summary>
        None,

        /// <summary>
        /// Solid wall.
        /// </summary>
        Wall,

        /// <summary>
        /// Wall with a visible door that can be walked through.
        /// </summary>
        Door,

        /// <summary>
        /// Wall with an invisible door that can be walked through.
        /// </summary>
        SecretDoor
    }
}
