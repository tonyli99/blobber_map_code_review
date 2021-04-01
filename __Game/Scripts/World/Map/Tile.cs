namespace Game
{
    using System;
    using UnityEngine;

    /// <summary>
    /// Data describing the geometry (walls/doors) of a square on a map.
    /// </summary>
    [Serializable]
    public class Tile
    {

        [SerializeField] private TilePrefab tilePrefab;
        [SerializeField] private WallType westWallType;
        [SerializeField] private WallType southWallType;

        public TilePrefab TilePrefab { get { return tilePrefab; } }
        public WallType WestWallType { get { return westWallType; } }
        public WallType SouthWallType { get { return southWallType; } }

    }
}
